using HexArch.Csv.AppServices.Api.Models;

namespace HexArch.Csv.AppServices.Api.Interfaces;

public interface IApiAppService
{
    int Add(AddFromPayloadRequest request);
}