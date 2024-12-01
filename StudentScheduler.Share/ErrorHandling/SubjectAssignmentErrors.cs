using StudentScheduler.Share.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScheduler.Share.ErrorHandling
{
	public record SubjectAssignmentErrors : Error
	{
		protected SubjectAssignmentErrors(string code, string message, ErrorType errorType) : base(code, message, errorType)
		{
		}

		public static Error AddSubjectAssignmentFailure = Conflict("SubjectAssignmentErrors.AddSubjectAssignmentFailure", "Error while adding subject assignment");
		public static Error SubjectAssignmentNotFound = NotFound("SubjectAssignmentErrors.SubjectAssignmentNotFound", "Subject assignment not found");
	}
}
