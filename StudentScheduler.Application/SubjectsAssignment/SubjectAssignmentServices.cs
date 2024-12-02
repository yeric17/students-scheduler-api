using StudentScheduler.Application.SubjectsAssignment.Responses;
using StudentScheduler.Domain.Abstractions;
using StudentScheduler.Share.Abstractions;

namespace StudentScheduler.Application.SubjectsAssignment
{
	internal class SubjectAssignmentServices : ISubjectAssignmentServices
	{
		private readonly ISubjectAssignmentRepository _subjectAssignmentRepository;

		public SubjectAssignmentServices(ISubjectAssignmentRepository subjectAssignmentRepository)
		{
			_subjectAssignmentRepository = subjectAssignmentRepository;
		}

		public Task<Result> AddSubjectAssignment(string subjectId, string teacherId)
		{
			
			return _subjectAssignmentRepository.AddSubjectAssignment(subjectId, teacherId);
		}

		public async Task<ResultValue<List<SubjectAssigmentGetResponse>>> GetSubjectsAssigment()
		{
			var results = await _subjectAssignmentRepository.GetSubjectsAssignment();

			if(results.IsFailure)
			{
				return results.Error!;
			}

			var subjectAssignmentResponses = results.Value.Select(subjectAssignment =>
				new SubjectAssigmentGetResponse {
					SubjectAssignmentId = subjectAssignment.SubjectAssignmentId,
					SubjectId = subjectAssignment.Subject.SubjectId,
					SubjectName = subjectAssignment.Subject.Name,
					TeacherId = subjectAssignment.Teacher.Id,
					TeacherName = $"{subjectAssignment.Teacher.FirstName} {subjectAssignment.Teacher.LastName}",
					StudentsCount = subjectAssignment.Enrollments != null ? subjectAssignment.Enrollments.Count : 0

                }).ToList();

			return subjectAssignmentResponses;
		}

		public async Task<ResultValue<List<SubjectAssigmentDetailGetResponse>>> GetSubjectsAssigmentDetail(string subjectAssigmentId)
		{
			var result = await _subjectAssignmentRepository.GetSubjectAssigmentDetail(subjectAssigmentId);

			if (result.IsFailure)
			{
				return result.Error!;
			}

			var subjectAssignments = result.Value;

			var response = subjectAssignments.Select(sa =>
			{
				var students = sa.Enrollments.Select(s =>
				{
					return new SubjectAssigmentStudent
					{
						FullName = $"{s.Student.FirstName} {s.Student.LastName}",
						UserId = s.StudentId
					};
				}).ToList();
				return new SubjectAssigmentDetailGetResponse
				{
					SubjectAssignmentId = sa.SubjectAssignmentId,
					SubjectId = sa.Subject.SubjectId,
					SubjectName = sa.Subject.Name,
					TeacherId = sa.Teacher.Id,
					TeacherName = $"{sa.Teacher.FirstName} {sa.Teacher.LastName}",
					Students = students,
					StudentsCount = students != null ? students.Count : 0
				};
			}).ToList();

			return response;
		}
	}
}
