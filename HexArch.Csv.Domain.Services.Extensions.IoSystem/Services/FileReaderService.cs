using HexArch.Csv.Domain.Entities;
using HexArch.Csv.Domain.Extensions;
using HexArch.Csv.Domain.Interfaces.Services;
using HexArch.Csv.Domain.Validations;

namespace HexArch.Csv.Domain.Services.Extensions.IoSystem.Services;

public class FileReaderService : IFileReaderService
{
    public IEnumerable<Person> Read(FileInfo file)
    {
        Validators.EnsureFileExists(file);
        Validators.EnsureFileIsNotEmpty(file);

        foreach (var line in File.ReadLines(file.FullName))
            yield return line.ToPerson();
    }
}