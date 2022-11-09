using FanOutFanInApplication;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(DurableFunctionFanOutFanIn.Startup))]
namespace DurableFunctionFanOutFanIn
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddApplication();
            builder.Services.AddHttpContextAccessor();
        }
    }
}
