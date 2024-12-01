using StudentScheduler.Share.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScheduler.Share.ErrorHandling
{
	public record UserErrors : Error
	{
		protected UserErrors(string code, string message, ErrorType errorType) : base(code, message, errorType)
		{
		}

		public static Error AssignUserRoleFailure(string userId, string roleId) => Conflict("UserErrors.AssignUserRoleFailure", $"Failed to assign role to user {userId} and role {roleId}");
		public static Error UserNotFound(string userId) => NotFound("UserErrors.UserNotFound", $"User with id {userId} not found");
		public static readonly Error UserConflict = Conflict("UserErrors.UpdateUserFailure", "Failed to update user");
	}
}
