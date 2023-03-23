using Dapper;
using HexArch.Csv.Domain.Entities;
using HexArch.Csv.Domain.Interfaces.Repositories;
using HexArch.Csv.Repositories.Queries;
using Microsoft.Extensions.Configuration;

namespace HexArch.Csv.Repositories.Repositories;

public class PeopleRepository : BaseRepository, IPeopleRepository
{
    public PeopleRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public Person Add(Person person)
    {
        return HandleDbErrors(() =>
        {
            using var connection = GetConnection();
            connection.Execute(PersonQueries.Queries.Insert, person);
            return person;
        }, typeof(Person));
    }
}