
using Microsoft.AspNetCore.Identity;
using StudentScheduler.Share.Abstractions;

namespace StudentScheduler.Domain.Abstractions
{
    public interface IRolesRepository
    {
        Task<ResultValue<IdentityRole>> GetRoleByName(string roleName);
    }
}
