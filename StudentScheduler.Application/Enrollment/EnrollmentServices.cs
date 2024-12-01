using StudentScheduler.Domain.Abstractions;
using StudentScheduler.Domain.Entities;
using StudentScheduler.Share.Abstractions;
using StudentScheduler.Share.ErrorHandling;

namespace StudentScheduler.Application.Enrollment
{
    internal class EnrollmentServices : IEnrollmentServices
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
		private readonly ISubjectAssignmentRepository _subjectAssignmentRepository;

		public EnrollmentServices(IEnrollmentRepository enrollmentRepository, ISubjectAssignmentRepository subjectAssignmentRepository)
		{
			_enrollmentRepository = enrollmentRepository;
			_subjectAssignmentRepository = subjectAssignmentRepository;
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
				return Result.Failure(subjectAssignmentResult.Error!);
			}

			if (studentEnrollmentsResult.IsFailure)
			{
				return Result.Failure(studentEnrollmentsResult.Error!);
			}

			var enrollmentsWithCurrentTeacher = studentEnrollmentsResult.Value.Where(e => e.SubjectAssignment.TeacherId == subjectAssignmentResult.Value.TeacherId).ToList();

			if (enrollmentsWithCurrentTeacher is not null && enrollmentsWithCurrentTeacher.Count > 0)
			{
				return Result.Failure(EnrollmentErrors.StudentAlreadyAssignedToTeacher);
			}

			return Result.Success();
		}
	}
}
