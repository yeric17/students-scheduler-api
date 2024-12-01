namespace StudentScheduler.Share.Abstractions
{
	public enum ErrorType
	{
		Empty = 0,
		Failure = 1,
		NotFound = 2,
		Validation = 3,
		Conflict = 4,
		AccessUnAuthorized = 5,
		AccessForbidden = 6,
	}
}
