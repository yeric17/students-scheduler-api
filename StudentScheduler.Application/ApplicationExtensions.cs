
using Microsoft.Extensions.DependencyInjection;

namespace StudentScheduler.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            return services;
        }
    }
}
