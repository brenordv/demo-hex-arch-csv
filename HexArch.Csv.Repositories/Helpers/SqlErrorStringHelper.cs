using System.Text.RegularExpressions;

namespace HexArch.Csv.Repositories.Helpers;

public static class SqlErrorStringHelper
{
    private static readonly Regex FkOperationPattern = new(@"The (\w+) statement", RegexOptions.IgnoreCase);

    private static readonly Regex
        NullColumnPattern = new(@"into column '(\w+)', table '(.+)'", RegexOptions.IgnoreCase);

    public static string GetOperationFromFkMessage(string message)
    {
        var match = FkOperationPattern.Match(message);
        return match.Success
            ? match.Groups[1].ToString()
            : "UNKNOWN-OPERATION";
    }

    public static (string column, string table) GetColumnAndTableFromNullColMessage(string message)
    {
        var match = NullColumnPattern.Match(message);
        return match.Success
            ? (match.Groups[1].ToString(), match.Groups[2].ToString())
            : ("unknown-column", "unknown-table");
    }
}