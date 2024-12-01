namespace StudentScheduler.Share.Abstractions
{
	public record Error
	{
		public string Code { get; private set; }
		public string Message { get; private set; }

		public ErrorType ErrorType { get; private set; }
		protected Error(string code, string message, ErrorType errorType)
		{
			Code = code;
			Message = message;
			ErrorType = errorType;
		}

		public static readonly Error Empty = new(string.Empty, string.Empty, ErrorType.Empty);

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
