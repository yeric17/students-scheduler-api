using StudentScheduler.Domain.Abstractions;
using StudentScheduler.Share.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
