using HexArch.Csv.Applications.AzFn.HttpTrigger;
using HexArch.Csv.AppServices.Api.Interfaces;
using HexArch.Csv.AppServices.Api.Services;
using HexArch.Csv.Infrastructure.Di.Extensions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace HexArch.Csv.Applications.AzFn.HttpTrigger;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services
            .AddInfrastructure()
            .AddAppSettings()
            .AddScoped<IApiAppService, ApiAppService>();
    }
}