namespace StudentScheduler.Share.Abstractions
{
	public record Error
	{
		public string Code { get; init; }
		public string Message { get; init; }

		public ErrorType ErrorType { get; init; }
		protected Error(string code, string message, ErrorType errorType)
		{
			Code = code;
			Message = message;
			ErrorType = errorType;
		}


		public static Error Failure(string code, string description) =>
			new(code, description, ErrorType.Failure);

		public static Error NotFound(string code, string description) =>
			new(code, description, ErrorType.NotFound);

		public static Error Validation(string code, string description) =>
			new(code, description, ErrorType.Validation);

		public static Error Conflict(string code, string description) =>
			new(code, description, ErrorType.Conflict);

		public static Error AccessUnAuthorized(string code, string description) =>
			new(code, description, ErrorType.AccessUnAuthorized);

		public static Error AccessForbidden(string code, string description) =>
			new(code, description, ErrorType.AccessForbidden);
	}
}
