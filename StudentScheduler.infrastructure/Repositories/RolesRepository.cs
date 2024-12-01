using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentScheduler.Domain.Abstractions;
using StudentScheduler.Domain.Entities;
using StudentScheduler.infrastructure.Abstractions;
using StudentScheduler.infrastructure.Data;
using StudentScheduler.Share.Abstractions;
using StudentScheduler.Share.ErrorHandling;

namespace StudentScheduler.infrastructure.Repositories
{
    internal class RolesRepository : BaseEFRepository, IRolesRepository
    {
        public RolesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ResultValue<IdentityRole>> GetRoleByName(string roleName)
        {
            var result = await  _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == roleName);

            if(result == null)
            {
                return ResultValue<IdentityRole>.Failure(RoleErrors.RoleNameNotFound(roleName));
            }

            return result;
        }

        public async Task<ResultValue<List<string>>> GetUserRoles(string userId)
        {
            var result = await _dbContext
                .UserRoles
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.RoleId)
                .ToListAsync();

            if (result is null) return new List<string>();

            var roles = await _dbContext.Roles
                .Where(r => result.Contains(r.Id) && r.Name != null)
                .Select(r => r.Name ?? "")
                .ToListAsync();

            if (roles is null) return new List<string>();

            return roles;

        }
    }
}
