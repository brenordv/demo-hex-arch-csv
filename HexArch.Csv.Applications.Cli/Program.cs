using HexArch.Csv.Applications.Cli.Printer;
using HexArch.Csv.AppServices.Cli.Interfaces;
using HexArch.Csv.AppServices.Cli.Models;
using HexArch.Csv.AppServices.Cli.Services;
using HexArch.Csv.Infrastructure.Di.Extensions;
using Microsoft.Extensions.DependencyInjection;

ConsolePrinter.PrintHeader();
try
{
    if (!args.Any())
    {
        ConsolePrinter.PrintUsage();
        Environment.Exit(-1);
    }

    var serviceProvider = new ServiceCollection()
        .AddInfrastructure()
        .AddScoped<ICliAppService, CliAppService>()
        .BuildServiceProvider();

    var service = serviceProvider.GetService<ICliAppService>();
    var qtyAdded = service.Add(new AddFromFileRequest
    {
        Filename = args[0]
    });

    Console.WriteLine($"Added {qtyAdded} people.");
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}
finally
{
    ConsolePrinter.PrintFooter();
}