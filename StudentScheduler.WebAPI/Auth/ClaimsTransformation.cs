using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using StudentScheduler.Application.Users;
using StudentScheduler.Domain.Entities;
using System.Security.Claims;

namespace StudentScheduler.WebAPI.Auth
{
	public class ClaimsTransformation : IClaimsTransformation
	{
		private readonly UserManager<User> _usersManager;
		private readonly IUsersService _usersService;

		public ClaimsTransformation(UserManager<User> usersManager, IUsersService usersService)
		{
			_usersManager = usersManager;
			_usersService = usersService;
		}

		public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
		{
			var identity = (ClaimsIdentity)principal.Identity;

			if(identity is null)
			{
				return principal;
			}

			var user = await _usersManager.GetUserAsync(principal);

			if (user is null )
			{
				return principal;
			}


			if (!principal.HasClaim(principal => principal.Type == "userId"))
			{
				identity.AddClaim(new Claim("userId", user.Id));
			}

			var rolesResult = await _usersService.GetUserRoles(user.Id);

			if (rolesResult.IsFailure)
			{
				return principal;
			}

			var roles = rolesResult.Value;

			if (!principal.HasClaim(principal => principal.Type == "role") && roles is not null)
			{
				foreach(var role in roles)
				{
					identity.AddClaim(new Claim("role", role));
				}
			}



			return principal;
		}
	}
}
