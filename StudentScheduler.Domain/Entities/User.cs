﻿using Microsoft.AspNetCore.Identity;

namespace StudentScheduler.Domain.Entities
{
    public class User : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
