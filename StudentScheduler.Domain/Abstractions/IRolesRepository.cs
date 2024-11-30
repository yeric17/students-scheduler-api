using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StudentScheduler.Domain.Abstractions
{
    public interface IRolesRepository
    {
        Task<IdentityRole> GetRoleByName(string roleName);
    }
}
