using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xunit;

namespace FunctionApp1Tests
{
    public class Function1Tests
    {
        private IHost _host;
        private FunctionApp1.Function1 _sut;

        public Function1Tests()
        {
            var startup = new FunctionApp1.Startup();
            _host = new HostBuilder()
                .ConfigureWebJobs(startup.Configure)
                .Build();

            _sut = new FunctionApp1.Function1();
        }

        [Fact]
        public void Test1()
        {
            var fixture = new Fixture();
            var name = fixture.Create<string>();

            var reqContext = new DefaultHttpContext();
            reqContext.Request.QueryString= new QueryString($"?name={name}");

            var expected = new Microsoft.AspNetCore.Mvc.OkObjectResult($"Hello, {name}. This HTTP triggered function executed successfully.");

            _sut.Run(reqContext.Request, Resolve<ILogger<FunctionApp1.Function1>>())
                .Result
                .Should()
                .BeEquivalentTo(expected);
        }

        private T Resolve<T>() where T : notnull => _host.Services.GetRequiredService<T>();
    }
}