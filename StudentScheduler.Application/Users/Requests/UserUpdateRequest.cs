using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScheduler.Application.Users.Requests
{
	public class UserUpdateRequest
	{
		public string? UserId { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
	}
}
