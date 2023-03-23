using HexArch.Csv.Domain.Entities;
using HexArch.Csv.Domain.Exceptions;
using HexArch.Csv.Domain.Interfaces.Repositories;
using HexArch.Csv.Domain.Interfaces.Services;
using HexArch.Csv.Domain.Validations;

namespace HexArch.Csv.Domain.Services.Services;

public class PeopleService : IPeopleService
{
    private readonly IPeopleRepository _peopleRepository;

    public PeopleService(IPeopleRepository peopleRepository)
    {
        _peopleRepository = peopleRepository;
    }

    public int Add(IEnumerable<Person> people)
    {
        Validators.EnsureIsNotNull(people);
        using var transaction = _peopleRepository.BeginTransaction();
        var addedCount = 0;
        Person person = null;
        try
        {
            using var enumerator = people.GetEnumerator();
            while (enumerator.MoveNext())
            {
                person = enumerator.Current;
                _peopleRepository.Add(person);
                addedCount++;
            }

            transaction.Complete();

            return addedCount;
        }
        catch (Exception e)
        {
            throw new HexServiceException($"Failed to add person #{addedCount + 1}: {person}", e);
        }
    }
}