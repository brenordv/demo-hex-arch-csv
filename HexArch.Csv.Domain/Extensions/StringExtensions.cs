using System.Globalization;
using HexArch.Csv.Domain.Entities;
using HexArch.Csv.Domain.Exceptions;

namespace HexArch.Csv.Domain.Extensions;

public static class StringExtensions
{
    public static Person ToPerson(this string text, string dateFormat = "yyyy-MM-dd")
    {
        var values = text.Split(',');
        if (values.Length != 2)
            throw new HexValidationException($"Invalid person format: {text}");

        return new Person
        {
            Name = values[0],
            BirthDate = DateTime.ParseExact(values[1], dateFormat, CultureInfo.InvariantCulture)
        };
    }
}