using AppCase.Core.Services;
using AppCase.Service;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.Application.Dependency
{
    public static class ServiceDependency
    {
        internal static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBookTraceService, BookTraceService>();
            services.AddScoped<ICountyService, CountyService>();
            return services;
        }
    }
}
