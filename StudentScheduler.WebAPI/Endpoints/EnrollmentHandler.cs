using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Win32;
using StudentScheduler.Application.Enrollment;
using StudentScheduler.Application.Enrollment.Requests;
using StudentScheduler.WebAPI.Endpoints.Utilities;

namespace StudentScheduler.WebAPI.Endpoints
{
	public static class EnrollmentHandler
	{
		
		public static RouteGroupBuilder MapEnrollment(this RouteGroupBuilder routes)
		{

			routes.MapPost("/", AddEnrollment);
			return routes;
		}

		[Authorize(Roles = "Student")]
        public static async Task<IResult> AddEnrollment(IEnrollmentServices enrollmentServices, EnrollmentAddRequest request)
		{
			var result = await enrollmentServices.AddEnrollment(request.SubjectAssignmentId, request.StudentId);
			if (result.IsFailure)
			{
				return ResponseManager.GetResponseErrorByResult(result);
			}
			return Results.NoContent();
		}
	}
}
