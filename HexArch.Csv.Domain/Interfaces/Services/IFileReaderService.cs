using HexArch.Csv.Domain.Entities;

namespace HexArch.Csv.Domain.Interfaces.Services;

public interface IFileReaderService
{
    IEnumerable<Person> Read(FileInfo file);
}