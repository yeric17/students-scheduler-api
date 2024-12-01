using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentScheduler.Domain.Entities;
using StudentScheduler.Application.Users.Requests;
using StudentScheduler.Application.Users;
using StudentScheduler.WebAPI.Endpoints.Utilities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using StudentScheduler.infrastructure.Abstractions;

namespace StudentScheduler.WebAPI.Endpoints
{
    public static class UsersHandler
    {
        private static readonly EmailAddressAttribute _emailAddressAttribute = new();
        
        public static RouteGroupBuilder MapUsers(this RouteGroupBuilder routes)
        {

            routes.MapPost("/register", Register);
            routes.MapPut("/update", Update);
            routes.MapGet("/me", GetMe);
            return routes;
        }

        [Authorize]
        public static async Task<IResult> GetMe(IClaimsHelper claimsHelper, IUsersService usersService)
        {
            var userId = claimsHelper.GetUserId();
            if (userId is null)
            {
                return Results.Unauthorized();
            }
            var result = await usersService.GetUserById(userId);
            if (result.IsFailure)
            {
                return ResponseManager.GetResponseErrorByResult(result);
            }
            return Results.Ok(result.Value);
        }


        public static async Task<IResult> Register([FromBody] UserRegisterRequest request, [FromServices] IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var usersService = serviceProvider.GetRequiredService<IUsersService>();

            if (!userManager.SupportsUserEmail)
            {
                throw new NotSupportedException($"{nameof(MapUsers)} requires a user store with email support.");
            }

            var userStore = serviceProvider.GetRequiredService<IUserStore<User>>();
            var emailStore = (IUserEmailStore<User>)userStore;
            var email = request.Email;

            if (string.IsNullOrEmpty(email) || !_emailAddressAttribute.IsValid(email))
            {
                return CreateValidationProblem(IdentityResult.Failed(userManager.ErrorDescriber.InvalidEmail(email)));
            }

            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            
            

            await userStore.SetUserNameAsync(user, email, CancellationToken.None);
            await emailStore.SetEmailAsync(user, email, CancellationToken.None);
            var result = await userManager.CreateAsync(user, request.Password);

            //Assign default role

            var storedUser = await userManager.FindByEmailAsync(email);

            if(storedUser is not null)
            {
                await usersService.AssignUserRole(storedUser.Id, "Student");
            }

            if (!result.Succeeded)
            {
                return CreateValidationProblem(result);
            }


            return Results.Created();
        }
		[Authorize]
		public static async Task<IResult> Update(IUsersService usersService, IClaimsHelper claimsHelper, UserUpdateRequest request)
		{
            var userId = claimsHelper.GetUserId();

            if(userId is null)
            {
                return Results.Unauthorized();
            }
            request.UserId = userId;

			var result = await usersService.UpdateUser(request);
			if (result.IsFailure)
			{
				return ResponseManager.GetResponseErrorByResult(result);
			}
			return Results.Ok();
		}

		private static ValidationProblem CreateValidationProblem(string errorCode, string errorDescription) =>
        TypedResults.ValidationProblem(new Dictionary<string, string[]> {
            { errorCode, [errorDescription] }
        });

        private static ValidationProblem CreateValidationProblem(IdentityResult result)
        {

            Debug.Assert(!result.Succeeded);
            var errorDictionary = new Dictionary<string, string[]>(1);

            foreach (var error in result.Errors)
            {
                string[] newDescriptions;

                if (errorDictionary.TryGetValue(error.Code, out var descriptions))
                {
                    newDescriptions = new string[descriptions.Length + 1];
                    Array.Copy(descriptions, newDescriptions, descriptions.Length);
                    newDescriptions[descriptions.Length] = error.Description;
                }
                else
                {
                    newDescriptions = [error.Description];
                }

                errorDictionary[error.Code] = newDescriptions;
            }

            return TypedResults.ValidationProblem(errorDictionary);
        }
    }
}
