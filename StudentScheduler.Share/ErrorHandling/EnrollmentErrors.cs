using StudentScheduler.Share.Abstractions;

namespace StudentScheduler.Share.ErrorHandling
{
	public record EnrollmentErrors : Error
	{
		protected EnrollmentErrors(string code, string message, ErrorType errorType) : base(code, message, errorType)
		{
		}

		public static Error AddEnrollmentFailure = Conflict("EnrollmentErrors.AddEnrollmentFailure","Add Enrollment failure");
		
		public static Error MaxSameTeacherAssigned(int max)  => Validation("EnrollmentErrors.StudentAlreadyAssignTeacher", $"Ya asignaste este profesor en otra materia");

		public static Error MaxEnrollmentReached(int max) => Validation("EnrollmentErrors.MaxEnrollmentReached", $"El limite de suscripciones se alcanzó. El máximo es {max}");

		public static readonly Error AlreadyEnrollment = Validation("EnrollmentErrors.AlreadyEnrollment", "Ya esta asignado a esta matería");

		public static Error EronllmentConflict(Exception e) => Conflict("EnrollmentErrors.EronllmentConflict","");
	}
}
