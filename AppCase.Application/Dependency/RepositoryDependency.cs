using AppCase.Core.Repository;
using AppCase.EFDataAccess;
using AppCase.EFDataAccess.Repository;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.Application.Dependency
{
    internal static class RepositoryDependency
    {
        internal static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBookTraceRepository, BookTraceRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryHolidayRepository, CountryHolidayRepository>();


            EFDatabaseContextFactory databaseContextFactory = new EFDatabaseContextFactory(configuration);
            EFDatabaseContext context = databaseContextFactory.CreateDbContext();

            EFDatabaseInitializer.Migrate(context);
            EFDatabaseInitializer.Initialize(context, configuration);


            return services;
        }
    }
}