using AutoFixture;
using FluentAssertions;
using FunctionApp1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xunit;

namespace FunctionApp1Tests
{
    public class Function1MockServiceTests
    {
        private IHost _host;
        private FunctionApp1.Function1 _sut;

        public Function1MockServiceTests()
        {
            var startup = new FunctionApp1.Startup();
            _host = new HostBuilder()
                .ConfigureWebJobs(startup.Configure)
                .ConfigureServices(services=>
                {
                    var descriptor = 
                    new ServiceDescriptor(
                            typeof(INameService),
                            typeof(MockNameService),
                            ServiceLifetime.Transient);

                    services.Replace(descriptor);
                })
                .Build();

            _sut = new FunctionApp1.Function1(Resolve<INameService>());
        }

        [Fact]
        public void Test1()
        {
            var fixture = new Fixture();
            var name = fixture.Create<string>();

            var reqContext = new DefaultHttpContext();
            reqContext.Request.QueryString= new QueryString($"?name={name}");

            var expected = new Microsoft.AspNetCore.Mvc.OkObjectResult($"{name}");

            _sut.Run(reqContext.Request, Resolve<ILogger<FunctionApp1.Function1>>())
                .Result
                .Should()
                .BeEquivalentTo(expected);
        }

        private T Resolve<T>() where T : notnull => _host.Services.GetRequiredService<T>();

        private class MockNameService : INameService
        {
            public string Message(string name)
            {
                return name;
            }
        }
    }
}