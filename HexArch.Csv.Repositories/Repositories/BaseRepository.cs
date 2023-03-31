using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using HexArch.Csv.Repositories.Helpers;
using Microsoft.Extensions.Configuration;

namespace HexArch.Csv.Repositories.Repositories;

public abstract class BaseRepository
{
    private readonly IConfiguration _configuration;

    protected BaseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected IDbConnection GetConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }


    public TransactionScope BeginTransaction()
    {
        return new TransactionScope();
    }

    protected static T HandleDbErrors<T>(Func<T> operation, Type entityType)
    {
        try
        {
            return operation();
        }
        catch (SqlException e)
        {
            throw SqlExceptionHelper.CreateRepositoryException(e, entityType);
        }
    }
}