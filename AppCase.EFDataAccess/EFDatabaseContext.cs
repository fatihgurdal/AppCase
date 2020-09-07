using AppCase.Core.Entities;
using AppCase.EFDataAccess.Mapping;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AppCase.EFDataAccess
{
    public class EFDatabaseContext : DbContext
    {
        public EFDatabaseContext(DbContextOptions<EFDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<BookTrace> BookTraces { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookTraceMapping());
            modelBuilder.ApplyConfiguration(new CountryMapping());
        }
    }

    public class EFDatabaseContextFactory : IDesignTimeDbContextFactory<EFDatabaseContext>
    {
        public IConfiguration Configuration { get; private set; }
        public EFDatabaseContextFactory()
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            // Build config
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
        public EFDatabaseContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public EFDatabaseContext CreateDbContext(params string[] args)
        {
            var connectionString = Configuration.GetConnectionString("DbConnection");
            var builder = new DbContextOptionsBuilder<EFDatabaseContext>();
            builder.UseSqlServer(connectionString);
            return new EFDatabaseContext(builder.Options);
        }
        public string GetConnectionString()
        {
            // Get environment
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Build config
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            return configuration.GetConnectionString("DbConnection");
        }
    }
}
