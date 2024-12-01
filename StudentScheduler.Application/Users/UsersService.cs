
using StudentScheduler.Domain.Abstractions;
using StudentScheduler.Share.Abstractions;

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
    }
}
