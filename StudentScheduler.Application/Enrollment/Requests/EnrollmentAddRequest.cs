using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScheduler.Application.Enrollment.Requests
{
	public record EnrollmentAddRequest
	{
		public required string SubjectAssignmentId { get; init; }
		public required string StudentId { get; init; }
	}
}
