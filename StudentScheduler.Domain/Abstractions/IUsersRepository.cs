using StudentScheduler.Share.Abstractions;

namespace StudentScheduler.Domain.Abstractions
{
    public interface IUsersRepository
    {
        Task<Result> AssignUserRole(string userId, string roleName);
    }
}
