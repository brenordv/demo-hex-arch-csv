using HexArch.Csv.AppServices.Cli.Models;

namespace HexArch.Csv.AppServices.Cli.Interfaces;

public interface ICliAppService
{
    int Add(AddFromFileRequest request);
}