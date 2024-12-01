using StudentScheduler.Domain.Entities;
using StudentScheduler.Share.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScheduler.Domain.Abstractions
{
	public interface ISubjectAssignmentRepository
	{
		Task<Result> AddSubjectAssignment(string subjectId, string teacherId);
		Task<ResultValue<SubjectAssignment>> GetSubjectAssigmentById(string subjectAssignmentId);
		Task<ResultValue<List<SubjectAssignment>>> GetSubjectsAssignment();
		Task<ResultValue<List<SubjectAssignment>>> GetSubjectsAssignmentByTeacherId(string teacherId);
	}
}
