using AppCase.Application.Dependency;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

using NUnit.Framework;

using System;
using System.IO;
using System.Reflection;

namespace AppCase.Service.Test
{
    public class BookTraceTests
    {
        readonly IServiceCollection _services = new ServiceCollection();

        [SetUp]
        public void Setup()
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Build config
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();


            _services.AddDbContextServices(configuration);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}