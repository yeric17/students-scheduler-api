using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScheduler.Application.Users.Responses
{
    public class UserGetResponse
    {
        public required string UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required string Email { get; set; }
    }
}
