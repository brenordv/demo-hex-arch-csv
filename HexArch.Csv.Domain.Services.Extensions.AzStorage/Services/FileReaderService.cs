using Azure.Storage.Blobs;
using HexArch.Csv.Domain.Entities;
using HexArch.Csv.Domain.Extensions;
using HexArch.Csv.Domain.Interfaces.Services;
using HexArch.Csv.Domain.Validations;
using Microsoft.Extensions.Configuration;

namespace HexArch.Csv.Domain.Services.Extensions.AzStorage.Services;

public class FileReaderService : IFileReaderService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly string _containerName;
    public FileReaderService(IConfiguration configuration)
    {
        _blobServiceClient = new BlobServiceClient(configuration["BlobConnectionString"]);
        _containerName = configuration["ContainerName"];
    }
    
    public IEnumerable<Person> Read(FileInfo file)
    {
        Validators.EnsureIsNotNull(file);
        
        var fileContent = GetFileContent(file.ToString());
        
        foreach (var line in fileContent.Split(Environment.NewLine))
            yield return line.ToPerson();
    }

    private string GetFileContent(string fileReference)
    {
        Validators.EnsureTextIsNotEmpty(fileReference);
        
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        var blobClient = containerClient.GetBlobClient(fileReference);
        
        var response = blobClient.Download();
        using var streamReader = new StreamReader(response.Value.Content);
        var fileContent = streamReader.ReadToEnd();
        
        return fileContent;
    }
}