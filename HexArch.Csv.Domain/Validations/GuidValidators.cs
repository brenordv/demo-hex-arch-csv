using HexArch.Csv.Domain.Exceptions;

namespace HexArch.Csv.Domain.Validations;

public static partial class Validators
{
    public static void EnsureIsNotEmptyGuid(Guid guid)
    {
        if (guid != Guid.Empty) return;
        throw new HexValidationException("Guid cannot be empty.");
    }
}