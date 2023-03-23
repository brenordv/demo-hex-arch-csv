using HexArch.Csv.AppServices.Cli.Extensions;
using HexArch.Csv.AppServices.Cli.Interfaces;
using HexArch.Csv.AppServices.Cli.Models;
using HexArch.Csv.Domain.Interfaces;
using HexArch.Csv.Domain.Interfaces.Services;

namespace HexArch.Csv.AppServices.Cli.Services;

public class CliAppService: ICliAppService
{
    private readonly IFileReaderService _fileReaderService;
    private readonly IPeopleService _peopleService;
    
    public CliAppService(IFileReaderService fileReaderService, IPeopleService peopleService)
    {
        _fileReaderService = fileReaderService;
        _peopleService = peopleService;
    }

    public int Add(AddFromFileRequest request)
    {
        request.EnsureIsValid();
        var people = _fileReaderService.Read(request);
        var quantityAdded = _peopleService.Add(people);
        return quantityAdded;
    }
}