using System;
using System.Collections.Generic;
using System.Text;

using AppCase.EFDataAccess;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppCase.Application.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            ServiceProvider provider = services.BuildServiceProvider();

            string connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<EFDatabaseContext>(x => x.UseSqlServer(connectionString));
            Environment.SetEnvironmentVariable("EF_CONNECTION_STRING", connectionString);

            services.AddRepositories(configuration);
            services.AddServices(configuration);
            services.AddValidations(configuration);
            return services;
        }
    }
}
