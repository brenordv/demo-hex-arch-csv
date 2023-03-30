using HexArch.Csv.Domain.Exceptions;

namespace HexArch.Csv.Domain.Validations;

public static partial class Validators
{
    public static void EnsureTextIsNotLongerThan(string text, int size, bool allowEmpty = false)
    {
        var isEmpty = string.IsNullOrWhiteSpace(text);
        if (allowEmpty && isEmpty) return;

        if (isEmpty)
            throw new HexValidationException($"Text {text} is empty.");

        if (text.Length <= size) return;
        throw new HexValidationException($"Text {text} is longer than {size} characters.");
    }

    public static void EnsureTextIsNotEmpty(string text)
    {
        if (!string.IsNullOrWhiteSpace(text)) return;
        throw new HexValidationException($"Text {text} is empty.");
    }
}