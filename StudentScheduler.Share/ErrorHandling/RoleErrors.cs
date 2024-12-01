using StudentScheduler.Share.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScheduler.Share.ErrorHandling
{
	public record RoleErrors : Error
	{
		protected RoleErrors(string code, string message, ErrorType errorType) : base(code, message, errorType)
		{
		}
		public static Error RoleNameNotFound(string roleName) => NotFound("RoleErrors.RoleNotFound", $"Role with name {roleName} not found");
		public static Error RoleIdNotFound(string roleId) => NotFound("RoleErrors.RoleNotFound", $"Role with id {roleId} not found");
	}
}
