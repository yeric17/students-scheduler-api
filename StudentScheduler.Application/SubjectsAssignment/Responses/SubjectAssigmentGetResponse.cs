using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScheduler.Application.SubjectsAssignment.Responses
{
	public class SubjectAssigmentGetResponse
	{
		public required string SubjectAssignmentId { get; set; }
		public required string SubjectId { get; set; }
		public required string SubjectName { get; set; }
		public required string TeacherId { get; set; }
		public required string TeacherName { get; set; }

		public required int StudentsCount { get; set; }
	}

	public class SubjectAssigmentDetailGetResponse : SubjectAssigmentGetResponse
	{
		public required List<SubjectAssigmentStudent> Students { get; set; }
	}

	public class SubjectAssigmentStudent
	{
		public required string UserId { get; set; }
		public required string FullName { get; set; }
	}
}
