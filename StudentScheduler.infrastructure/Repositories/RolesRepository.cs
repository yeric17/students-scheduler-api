using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentScheduler.Domain.Abstractions;
using StudentScheduler.infrastructure.Abstractions;
using StudentScheduler.infrastructure.Data;

namespace StudentScheduler.infrastructure.Repositories
{
    internal class RolesRepository : BaseEFRepository, IRolesRepository
    {
        public RolesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IdentityRole> GetRoleByName(string roleName)
        {
            var result = await  _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == roleName);

            if(result == null)
            {
                throw new Exception($"Role {roleName} not found");
            }

            return result;
        }
    }
}
