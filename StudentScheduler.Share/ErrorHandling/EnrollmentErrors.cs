using StudentScheduler.Share.Abstractions;

namespace StudentScheduler.Share.ErrorHandling
{
	public record EnrollmentErrors : Error
	{
		protected EnrollmentErrors(string code, string message, ErrorType errorType) : base(code, message, errorType)
		{
		}

		public static Error AddEnrollmentFailure = Conflict("EnrollmentErrors.AddEnrollmentFailure","Add Enrollment failure");
		
		public static Error MaxSameTeacherAssigned(int max)  => Validation("EnrollmentErrors.StudentAlreadyAssignTeacher", $"Max assignet with the same teacher is {max}");

		public static Error MaxEnrollmentReached(int max) => Validation("EnrollmentErrors.MaxEnrollmentReached", $"Max enrollment reached. Max is {max}");
	}
}
