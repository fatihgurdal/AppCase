using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCase.EFDataAccess
{
    public class EFDatabaseInitializer
    {
        public static void Migrate(EFDatabaseContext context)
        {
            context.Database.Migrate();
        }
        public static void Initialize(EFDatabaseContext context, IConfiguration configuration)
        {
            AddCountries(context, configuration);
        }
        private static void AddCountries(EFDatabaseContext context, IConfiguration configuration)
        {

            if (!context.Countries.Any())
            {
                context.Countries.Add(new Core.Entities.Country()
                {
                    Name = "Turkey",
                    Culture = "tr-TR"
                });
                context.Countries.Add(new Core.Entities.Country()
                {
                    Name = "United Kingdom",
                    Culture = "en-GB"
                });
                context.Countries.Add(new Core.Entities.Country()
                {
                    Name = "Dubai",
                    Culture = "ar-AE"
                });
                context.SaveChanges();
            }

        }
    }
}
