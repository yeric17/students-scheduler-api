
using Microsoft.Extensions.DependencyInjection;
using StudentScheduler.Application.Enrollment;
using StudentScheduler.Application.SubjectsAssignment;
using StudentScheduler.Application.Users;

namespace StudentScheduler.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IEnrollmentServices, EnrollmentServices>();
            services.AddTransient<ISubjectAssignmentServices, SubjectAssignmentServices>();

			return services;
        }
    }
}
