using HexArch.Csv.Domain.Exceptions;

namespace HexArch.Csv.Domain.Validations;

public static partial class Validators
{
    public static void EnsureIsNotNull(object obj)
    {
        if (obj is not null) return;
        throw new HexValidationException("Object is null.");
    }
}