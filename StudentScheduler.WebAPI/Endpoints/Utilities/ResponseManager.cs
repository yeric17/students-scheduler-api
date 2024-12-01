using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentScheduler.Share.Abstractions;

namespace StudentScheduler.WebAPI.Endpoints.Utilities
{
	public class ResponseManager
	{
		public static IResult GetResponseErrorByResult(Result result)
		{
			switch (result.Error.ErrorType)
			{
				case ErrorType.Empty:
					return Results.Conflict("Error without description");
				case ErrorType.Failure:
					return Results.Problem(new ProblemDetails
					{
						Status = 500,
						Title = "Internal Server Error",
						Detail = result.Error.Message
					});
				case ErrorType.NotFound:
					return Results.NotFound(result.Error);
				case ErrorType.Validation:
					return Results.BadRequest(result.Error);
				case ErrorType.Conflict:
					return Results.Conflict(result.Error);
				case ErrorType.AccessUnAuthorized:
					return Results.Unauthorized();
				case ErrorType.AccessForbidden:
					return Results.Forbid();
				default:
					return Results.Conflict();
			}
		}
	}
}
