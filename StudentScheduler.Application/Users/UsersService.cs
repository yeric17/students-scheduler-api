
using StudentScheduler.Application.Users.Requests;
using StudentScheduler.Application.Users.Responses;
using StudentScheduler.Domain.Abstractions;
using StudentScheduler.Share.Abstractions;
using StudentScheduler.Share.ErrorHandling;

namespace StudentScheduler.Application.Users
{
    internal class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IRolesRepository _rolesRepository;
        public UsersService(IUsersRepository usersRepository, IRolesRepository rolesRepository)
        {
            _usersRepository = usersRepository;
            _rolesRepository = rolesRepository;
        }

        public async Task<Result> AssignUserRole(string userId, string roleName)
        {
            var roleResult = await _rolesRepository.GetRoleByName(roleName);

            if (roleResult.IsFailure)
            {
                return Result.Failure(roleResult.Error!);
            }
            var role = roleResult.Value;
			await _usersRepository.AssignUserRole(userId,role.Id);

            return Result.Success();
		}

		public async Task<Result> UpdateUser(UserUpdateRequest request)
        {
			return await _usersRepository.UpdateUser(request.UserId!, request.FirstName, request.LastName);
		}

        public Task<ResultValue<List<string>>> GetUserRoles(string userId)
		{
			return _rolesRepository.GetUserRoles(userId);
		}

        public async Task<ResultValue<UserGetResponse>> GetUserById(string userId)
        {
            var result = await _usersRepository.GetUserById(userId);

            if (result.IsFailure)
            {
                return UserErrors.UserNotFound(userId);
            }

            var user = new UserGetResponse
            {
                UserId = userId,
                FirstName = result.Value.FirstName,
                LastName = result.Value.LastName,
                Email = result.Value.Email ?? ""
            };

            return user;
        }

    }
}
