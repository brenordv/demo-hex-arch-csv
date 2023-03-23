using HexArch.Csv.Domain.Exceptions;

namespace HexArch.Csv.Domain.Validations;

public static partial class Validators
{
    public static void EnsureFileExists(FileInfo file)
    {
        if (file.Exists) return;
        throw new HexValidationException($"File {file.FullName} does not exist.");
    }
    
    public static void EnsureFileIsNotEmpty(FileInfo file)
    {
        if (file.Length > 0) return;
        throw new HexValidationException($"File {file.FullName} is empty.");
    }
}