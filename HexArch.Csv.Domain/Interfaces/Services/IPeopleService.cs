using HexArch.Csv.Domain.Entities;

namespace HexArch.Csv.Domain.Interfaces.Services;

public interface IPeopleService
{
    int Add(IEnumerable<Person> people);
}