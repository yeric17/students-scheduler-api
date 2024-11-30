﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentScheduler.infrastructure.Data;

namespace StudentScheduler.infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string not found");
            }

            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseMySQL(connectionString));

            return services;
        }
    }
}
