using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.Application.Dependency
{
    public static class ValidationInjection
    {
        //TODO: sürem uzadığı için validation implemente yapılmamıştır.
        internal static IServiceCollection AddValidations(this IServiceCollection services, IConfiguration configuration)
        {
            // services.AddTransient<IValidator<Request>, Validation>();


            return services;
        }
    }
}
