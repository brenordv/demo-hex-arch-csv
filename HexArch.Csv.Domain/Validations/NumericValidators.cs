using HexArch.Csv.Domain.Exceptions;

namespace HexArch.Csv.Domain.Validations;

public static partial class Validators
{
    public static void EnsureGreaterThan(int value, int min)
    {
        if (value > min) return;
        throw new HexValidationException($"Value {value} is not greater than {min}.");
    }

    public static void EnsureGreaterThanZero(int value)
    {
        EnsureGreaterThan(value, 0);
    }
}