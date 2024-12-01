using StudentScheduler.Application.SubjectsAssignment.Responses;
using StudentScheduler.Share.Abstractions;

namespace StudentScheduler.Application.SubjectsAssignment
{
	public interface ISubjectAssignmentServices
	{
		Task<Result> AddSubjectAssignment(string subjectId, string teacherId);
		Task<ResultValue<List<SubjectAssigmentGetResponse>>> GetSubjectsAssigment();
	}
}
