
using Microsoft.Extensions.Configuration;
using StudentScheduler.Application.Enrollment.Requests;
using StudentScheduler.Application.Enrollment.Responses;
using StudentScheduler.Domain.Abstractions;
using StudentScheduler.Domain.Entities;
using StudentScheduler.infrastructure.Abstractions;
using StudentScheduler.Share.Abstractions;
using StudentScheduler.Share.ErrorHandling;

namespace StudentScheduler.Application.Enrollment
{
    internal class EnrollmentServices : IEnrollmentServices
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
		private readonly ISubjectAssignmentRepository _subjectAssignmentRepository;
		private readonly IClaimsHelper _claimsHelper; 
		private int _maxSubjectEnrollment = 3;
		private int _maxSameTeacherAssigned = 1;


        public EnrollmentServices(IEnrollmentRepository enrollmentRepository, ISubjectAssignmentRepository subjectAssignmentRepository, IConfiguration configuration, IClaimsHelper claimsHelper)
        {
            _enrollmentRepository = enrollmentRepository;
            _subjectAssignmentRepository = subjectAssignmentRepository;
            _maxSubjectEnrollment = configuration.GetValue<int>("MaxSubjectEnrollment");
            _maxSameTeacherAssigned = configuration.GetValue<int>("MaxSameTeacherAssigned");
            _claimsHelper = claimsHelper;
        }

        public async Task<Result> AddEnrollment(string subjectAssignmentId, string studentId)
		{

			var validEnrollmentResult = await IsValidEnrollment(subjectAssignmentId, studentId);

			if (validEnrollmentResult.IsFailure)
			{
				return Result.Failure(validEnrollmentResult.Error!);
			}

			var enrollmentResult = await _enrollmentRepository.AddEnrollment(subjectAssignmentId, studentId);

			if (enrollmentResult.IsFailure)
			{
				return Result.Failure(enrollmentResult.Error!);
			}

			return Result.Success();
		}

		public async Task<ResultValue<List<EnrollmentGetResponse>>> GetUserEnrollments()
		{
			var userId = _claimsHelper.GetUserId();
			if(userId is null)
			{
                return UserErrors.UserNotFound(userId);
            }

            var enrollmentsResult = await _enrollmentRepository.GetStudentEnrollments(userId);

            if (enrollmentsResult.IsFailure)
            {
                return enrollmentsResult.Error!;
            }

            var enrollments = enrollmentsResult.Value.Select(e => new EnrollmentGetResponse
            {
                EnrollmentId = e.EnrollmentId,
                SubjectAssignmentId = e.SubjectAssignmentId,
                StudentId = e.StudentId,
            }).ToList();

            if (enrollments is null)
			{
				return new List<EnrollmentGetResponse>();
            }

            return enrollments;
        }

		public Task<Result> RemoveEnrollment(EnrollmentRemoveRequest request)
		{
			return _enrollmentRepository.RemoveEnrollment(request.SubjectAssignmentId, request.UserId);
		}

		private async Task<Result> IsValidEnrollment(string subjectAssignmentId, string studentId)
		{
			var subjectAssignmentResult = await _subjectAssignmentRepository.GetSubjectAssigmentById(subjectAssignmentId);

			var studentEnrollmentsResult = await _enrollmentRepository.GetStudentEnrollments(studentId);

			if (subjectAssignmentResult.IsFailure)
			{
				return subjectAssignmentResult.Error!;
			}

			if (IsAlreadyAssigned(subjectAssignmentId, subjectAssignmentResult, studentEnrollmentsResult))
			{
				return EnrollmentErrors.AlreadyEnrollment;
			}

			if (studentEnrollmentsResult.Value.Count == _maxSubjectEnrollment)
			{
				return EnrollmentErrors.MaxEnrollmentReached(_maxSubjectEnrollment);
			}

			if (studentEnrollmentsResult.IsFailure)
			{
				return studentEnrollmentsResult.Error!;
			}

			var enrollmentsWithCurrentTeacher = studentEnrollmentsResult.Value.Where(e => e.SubjectAssignment.TeacherId == subjectAssignmentResult.Value.TeacherId).ToList();

			if (enrollmentsWithCurrentTeacher is not null && enrollmentsWithCurrentTeacher.Count == _maxSameTeacherAssigned)
			{
				return Result.Failure(EnrollmentErrors.MaxSameTeacherAssigned(_maxSameTeacherAssigned));
			}

			return Result.Success();
		}

		private bool IsAlreadyAssigned(string subjectAssignmentId, ResultValue<SubjectAssignment> subjectAssignmentResult, ResultValue<List<Domain.Entities.Enrollment>> studentEnrollmentsResult)
		{
			return studentEnrollmentsResult.Value.Any(er => er.SubjectAssignmentId == subjectAssignmentId || er.SubjectAssignment.SubjectId == subjectAssignmentResult.Value.SubjectId);
		}
	}
}
