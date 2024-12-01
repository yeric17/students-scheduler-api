
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentScheduler.Domain.Abstractions;
using StudentScheduler.Share.Abstractions;
using StudentScheduler.Share.ErrorHandling;

namespace StudentScheduler.Application.Enrollment
{
    internal class EnrollmentServices : IEnrollmentServices
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
		private readonly ISubjectAssignmentRepository _subjectAssignmentRepository;
		private int _maxSubjectEnrollment = 3;
		private int _maxSameTeacherAssigned = 1;


		public EnrollmentServices(IEnrollmentRepository enrollmentRepository, ISubjectAssignmentRepository subjectAssignmentRepository, IConfiguration configuration)
		{
			_enrollmentRepository = enrollmentRepository;
			_subjectAssignmentRepository = subjectAssignmentRepository;
			_maxSubjectEnrollment = configuration.GetValue<int>("MaxSubjectEnrollment");
			_maxSameTeacherAssigned = configuration.GetValue<int>("MaxSameTeacherAssigned");

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

		private async Task<Result> IsValidEnrollment(string subjectAssignmentId, string studentId)
		{
			var subjectAssignmentResult = await _subjectAssignmentRepository.GetSubjectAssigmentById(subjectAssignmentId);

			var studentEnrollmentsResult = await _enrollmentRepository.GetStudentEnrollments(studentId);

			if (subjectAssignmentResult.IsFailure)
			{
				return Result.Failure(subjectAssignmentResult.Error);
			}

			if(studentEnrollmentsResult.Value.Count == _maxSubjectEnrollment)
			{
				return Result.Failure(EnrollmentErrors.MaxEnrollmentReached(_maxSubjectEnrollment));
			}

			if (studentEnrollmentsResult.IsFailure)
			{
				return Result.Failure(studentEnrollmentsResult.Error);
			}

			var enrollmentsWithCurrentTeacher = studentEnrollmentsResult.Value.Where(e => e.SubjectAssignment.TeacherId == subjectAssignmentResult.Value.TeacherId).ToList();

			if (enrollmentsWithCurrentTeacher is not null && enrollmentsWithCurrentTeacher.Count == _maxSameTeacherAssigned)
			{
				return Result.Failure(EnrollmentErrors.MaxSameTeacherAssigned(_maxSameTeacherAssigned));
			}

			return Result.Success();
		}
	}
}
