using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StudentScheduler.Domain.Abstractions;
using StudentScheduler.infrastructure.Abstractions;
using StudentScheduler.infrastructure.Data;

namespace StudentScheduler.infrastructure.Repositories
{
    internal class UsersRepository : BaseEFRepository, IUsersRepository
    {
        public UsersRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AssignUserRole(string userId, string roleId)
        {

            var userRole = new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            };

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error while assigning role to user.", e);
            }
        }
    }
}
