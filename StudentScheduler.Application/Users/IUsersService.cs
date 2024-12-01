using StudentScheduler.Share.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScheduler.Application.Users
{
    public interface IUsersService
    {
        Task<Result> AssignUserRole(string userId, string roleName);
    }
}
