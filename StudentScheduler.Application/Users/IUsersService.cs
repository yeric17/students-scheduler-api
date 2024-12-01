using StudentScheduler.Application.Users.Requests;
using StudentScheduler.Application.Users.Responses;
using StudentScheduler.Share.Abstractions;


namespace StudentScheduler.Application.Users
{
    public interface IUsersService
    {
        Task<Result> AssignUserRole(string userId, string roleName);
        Task<ResultValue<UserGetResponse>> GetUserById(string userId);
        Task<ResultValue<List<string>>> GetUserRoles(string userId);
		Task<Result> UpdateUser(UserUpdateRequest request);
	}
}
