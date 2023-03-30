using System.IO;
using System.Threading.Tasks;
using HexArch.Csv.AppServices.Api.Interfaces;
using HexArch.Csv.AppServices.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace HexArch.Csv.Applications.AzFn.HttpTrigger;

public class HttpTriggerFunction
{
    private readonly IApiAppService _apiAppService;

    public HttpTriggerFunction(IApiAppService apiAppService)
    {
        _apiAppService = apiAppService;
    }

    [FunctionName("HttpTriggerFunction")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
        HttpRequest req)
    {
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

        var qtyAdded = _apiAppService.Add(new AddFromPayloadRequest
        {
            Payload = requestBody
        });

        return new OkObjectResult(qtyAdded);
    }
}