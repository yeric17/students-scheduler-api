using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StudentScheduler.Domain.Abstractions;
using StudentScheduler.infrastructure.Abstractions;
using StudentScheduler.infrastructure.Data;
using StudentScheduler.Share.Abstractions;
using StudentScheduler.Share.ErrorHandling;

namespace StudentScheduler.infrastructure.Repositories
{
    internal class UsersRepository : BaseEFRepository, IUsersRepository
    {
        public UsersRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Result> AssignUserRole(string userId, string roleId)
        {

            var userRole = new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            };

            _dbContext.UserRoles.Add(userRole);

            try
            {
                await _dbContext.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Result.Failure(UserErrors.AssignUserRoleFailure(userId, roleId));
            }
        }

        public async Task<Result> UpdateUser(string userId, string? firstName, string? lastName)
        {
            var user = await _dbContext.Users.FindAsync(userId);

            if (user == null)
            {
                return UserErrors.UserNotFound(userId);
            }
            if(!string.IsNullOrWhiteSpace(firstName))
            {
                user.FirstName = firstName;
            }
            if(!string.IsNullOrWhiteSpace(lastName))
            {
                user.LastName = lastName;
            }
            try
            {
                await _dbContext.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return UserErrors.UserConflict;
            }
        }
    }
}
