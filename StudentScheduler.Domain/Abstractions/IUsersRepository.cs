using StudentScheduler.Domain.Entities;
using StudentScheduler.Share.Abstractions;

namespace StudentScheduler.Domain.Abstractions
{
    public interface IUsersRepository
    {
        Task<Result> AssignUserRole(string userId, string roleName);
		Task<Result> UpdateUser(string userId, string? firstName, string? lastName);
        Task<ResultValue<User>> GetUserById(string userId);
    }
}
