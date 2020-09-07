using AppCase.Application.Dependency;
using AppCase.Core.Exception;
using AppCase.Core.Services;
using AppCase.Core.ViewModel.BookTrace.Request;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

using NUnit.Framework;

using Shouldly;

using System;
using System.IO;
using System.Reflection;

namespace AppCase.Service.Test
{
    public class BookTraceTests
    {
        readonly IServiceCollection _services = new ServiceCollection();
        IServiceProvider _serviceProvider;

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

            _serviceProvider = _services.BuildServiceProvider();
        }

        [Test]
        public void Calculate_Country()
        {
            var bookTraceService = _serviceProvider.GetRequiredService<IBookTraceService>();

            var request = new CalculateRequest()
            {
                BookCheckoutDate = DateTime.Now,
                BookReturnDate = DateTime.Now.AddDays(3),
                CountryCulture = ""
            };
            Should.Throw<NotFoundExcepiton>(() => bookTraceService.Calculate(request));
        }
        [Test]
        public void Calculate_Date()
        {
            var bookTraceService = _serviceProvider.GetRequiredService<IBookTraceService>();

            var request = new CalculateRequest()
            {
                BookCheckoutDate = DateTime.Now.AddDays(3),
                BookReturnDate = DateTime.Now,
                CountryCulture = "tr-TR"
            };
            Should.Throw<BadRequestException>(() => bookTraceService.Calculate(request));
        }
        [Test]
        public void Calculate_Calculate()
        {
            var bookTraceService = _serviceProvider.GetRequiredService<IBookTraceService>();

            var request = new CalculateRequest()
            {
                BookCheckoutDate = new DateTime(2020, 9, 7),
                BookReturnDate = new DateTime(2020, 9, 21),
                CountryCulture = "tr-TR"
            };
            var response = bookTraceService.Calculate(request);

            response.PenaltyAmount.ShouldBe(15);
        }
        [Test]
        public void Calculate_NoPenaltyCalculate()
        {
            var bookTraceService = _serviceProvider.GetRequiredService<IBookTraceService>();

            var request = new CalculateRequest()
            {
                BookCheckoutDate = new DateTime(2020, 9, 7),
                BookReturnDate = new DateTime(2020, 9, 16),
                CountryCulture = "tr-TR"
            };
            var response = bookTraceService.Calculate(request);

            response.PenaltyAmount.ShouldBe(0);
        }
    }
}