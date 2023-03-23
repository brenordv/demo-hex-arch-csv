using HexArch.Csv.Domain.Exceptions;

namespace HexArch.Csv.Domain.Validations;

public static partial class Validators
{
    private static readonly DateTime SqlServerMinDate = new(1753, 1, 1);

    public static void EnsureDateIsInPast(DateTime date)
    {
        if (date <= DateTime.Now) return;
        throw new HexValidationException($"Date {date} is not in the past.");
    }

    public static void EnsureDateIsAfterSqlServerMin(DateTime date)
    {
        if (date >= SqlServerMinDate) return;
        throw new HexValidationException($"Date {date} is before the minimum date for SQL Server.");
    }

    public static void EnsureDateIsNotMax(DateTime date)
    {
        if (date != DateTime.MaxValue) return;
        throw new HexValidationException($"Date {date} is the maximum date.");
    }
}