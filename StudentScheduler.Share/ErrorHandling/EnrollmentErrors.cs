using StudentScheduler.Share.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScheduler.Share.ErrorHandling
{
	public record EnrollmentErrors : Error
	{
		protected EnrollmentErrors(string code, string message, ErrorType errorType) : base(code, message, errorType)
		{
		}

		public static Error AddEnrollmentFailure = Conflict("EnrollmentErrors.AddEnrollmentFailure","Add Enrollment failure");
		//el estudiante solo puede tener una clase con cada profesor
		public static Error StudentAlreadyAssignedToTeacher = Conflict("EnrollmentErrors.StudentAlreadyAssignTeacher", "Student already assign teacher");
	}
}
