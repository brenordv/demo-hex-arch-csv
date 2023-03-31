using HexArch.Csv.Applications.AzFn.TimerTrigger;
using HexArch.Csv.AppServices.Cli.Interfaces;
using HexArch.Csv.AppServices.Cli.Services;
using HexArch.Csv.Domain.Interfaces.Services;
using HexArch.Csv.Domain.Services.Extensions.AzStorage.Services;
using HexArch.Csv.Infrastructure.Di.Extensions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace HexArch.Csv.Applications.AzFn.TimerTrigger;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services
            .AddInfrastructure()
            .AddAppSettings()
            .AddSingleton<IFileReaderService, FileReaderService>()
            .AddScoped<ICliAppService, CliAppService>();
    }
}