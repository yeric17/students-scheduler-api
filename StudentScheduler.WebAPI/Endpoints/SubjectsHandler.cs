using Microsoft.AspNetCore.Mvc;
using StudentScheduler.Application.SubjectsAssignment;

namespace StudentScheduler.WebAPI.Endpoints
{
	public static class SubjectsHandler
	{
		public static RouteGroupBuilder MapSubjects(this RouteGroupBuilder routes)
		{
			routes.MapGet("/", GetSubjects);
			routes.MapGet("/{subjectAssignmentId}", GetSubjectDetail);
			return routes;
		}
	
		public static async Task<IResult> GetSubjects(ISubjectAssignmentServices subjectsService)
		{
			var subjects = await subjectsService.GetSubjectsAssigment();
			return Results.Ok(subjects);
		}

		public static async Task<IResult> GetSubjectDetail(ISubjectAssignmentServices subjectsService,[FromRoute] string subjectAssignmentId)
		{
			var subjects = await subjectsService.GetSubjectAssigmentDetail(subjectAssignmentId);
			return Results.Ok(subjects);
		}

		
	}
}
