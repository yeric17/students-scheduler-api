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
	}
}
