using System;
using System.Threading.Tasks;
using HexArch.Csv.AppServices.Cli.Interfaces;
using HexArch.Csv.AppServices.Cli.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace HexArch.Csv.Applications.AzFn.TimerTrigger;

public  class TimerTriggerFunction
{
    private readonly ICliAppService _cliAppService;

    public TimerTriggerFunction(ICliAppService cliAppService)
    {
        _cliAppService = cliAppService;
    }

    [FunctionName("TimerTriggerFunction")]
    public void Run([TimerTrigger("0 */5 * * * *", RunOnStartup = true)] TimerInfo myTimer)
    {
        var request = new AddFromFileRequest
        {
            Filename = "test_data_1k.csv",
            RequestedAt = DateTime.Now
        };


        var qtyAdded = _cliAppService.Add(request);
        Console.WriteLine($"Added {qtyAdded} records.");
    }
}