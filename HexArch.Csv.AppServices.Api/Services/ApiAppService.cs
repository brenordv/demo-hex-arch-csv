using HexArch.Csv.AppServices.Api.Extensions;
using HexArch.Csv.AppServices.Api.Interfaces;
using HexArch.Csv.AppServices.Api.Models;
using HexArch.Csv.Domain.Extensions;
using HexArch.Csv.Domain.Interfaces.Services;

namespace HexArch.Csv.AppServices.Api.Services;

public class ApiAppService : IApiAppService
{
    private readonly IPeopleService _peopleService;

    public ApiAppService(IPeopleService peopleService)
    {
        _peopleService = peopleService;
    }

    public int Add(AddFromPayloadRequest request)
    {
        request.EnsureIsValid();
        var people = request.Payload.Split("\n").Select(line => line.ToPerson());
        return _peopleService.Add(people);
    }
}