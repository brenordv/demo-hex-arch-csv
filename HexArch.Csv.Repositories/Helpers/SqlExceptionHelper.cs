using System.Data.SqlClient;
using HexArch.Csv.Domain.Exceptions;
using HexArch.Csv.Repositories.Constants;

namespace HexArch.Csv.Repositories.Helpers;

public static class SqlExceptionHelper
{
    public static HexRepositoryException CreateRepositoryException(SqlException exception, Type entityType)
    {
        var entityName = entityType.Name;
        switch (exception.Number)
        {
            case DatabaseConstants.SqlServer.ErrorCodes.FkViolation:
                var operation = SqlErrorStringHelper.GetOperationFromFkMessage(exception.Message);
                return new HexRepositoryException($"The {entityName} {operation} violated an FK constraint.",
                    exception);

            case DatabaseConstants.SqlServer.ErrorCodes.NotNullFieldMissing:
                var (column, table) = SqlErrorStringHelper.GetColumnAndTableFromNullColMessage(exception.Message);
                return new HexRepositoryException(
                    $"An operation on {entityName} (using table {table}) is missing value for column {column}.",
                    exception);

            case DatabaseConstants.SqlServer.ErrorCodes.ConnectionError:
                return new HexRepositoryException("Could not establish connection with database.", exception);

            default:
                return new HexRepositoryException("Unexpected Sql exception.", exception);
        }
    }
}