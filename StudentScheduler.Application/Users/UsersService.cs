
using StudentScheduler.Domain.Abstractions;

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

        public async Task AssignUserRole(string userId, string roleName)
        {
            var role = await _rolesRepository.GetRoleByName(roleName);

            if (role == null)
            {
                throw new Exception("Role not found.");
            }
            await _usersRepository.AssignUserRole(userId, role.Id);
        }
    }
}
