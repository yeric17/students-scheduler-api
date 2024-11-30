
using Microsoft.Extensions.DependencyInjection;
using StudentScheduler.Application.Users;

namespace StudentScheduler.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IUsersService, UsersService>();
            return services;
        }
    }
}
