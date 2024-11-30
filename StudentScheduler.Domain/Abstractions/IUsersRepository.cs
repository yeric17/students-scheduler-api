using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScheduler.Domain.Abstractions
{
    public interface IUsersRepository
    {
        Task AssignUserRole(string userId, string roleName);
    }
}
