using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using StudentScheduler.Application.Enrollment;
using StudentScheduler.Application.Enrollment.Requests;
using StudentScheduler.infrastructure.Abstractions;
using StudentScheduler.WebAPI.Endpoints.Utilities;

namespace StudentScheduler.WebAPI.Endpoints
{
	public static class EnrollmentHandler
	{
		
		public static RouteGroupBuilder MapEnrollment(this RouteGroupBuilder routes)
		{

			routes.MapPost("/", AddEnrollment);
            routes.MapGet("/", GetUserEnrollments);
			routes.MapDelete("/{subjectAssignmentId}",RemoveEnrollment);
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

        [Authorize(Roles = "Student")]
        public static async Task<IResult> RemoveEnrollment(IEnrollmentServices enrollmentServices, IClaimsHelper claimsHelper,[FromRoute] string subjectAssignmentId)
		{
			var userId = claimsHelper.GetUserId();

			if(userId is null)
			{
				return Results.Unauthorized();
			}

			var result = await enrollmentServices.RemoveEnrollment(new EnrollmentRemoveRequest
			{
				SubjectAssignmentId = subjectAssignmentId,
				UserId = userId
			});

			if (result.IsFailure)
			{
				return ResponseManager.GetResponseErrorByResult(result);
			}

			return Results.NoContent();
		}
        [Authorize(Roles = "Student")]
        public static async Task<IResult> GetUserEnrollments(IEnrollmentServices enrollmentServices)
        {
            var result = await enrollmentServices.GetUserEnrollments();
            if (result.IsFailure)
            {
                return ResponseManager.GetResponseErrorByResult(result);
            }
            return Results.Ok(result.Value);
        }

		
    }
}
