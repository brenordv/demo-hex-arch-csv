namespace HexArch.Csv.Repositories.Constants;

public static class DatabaseConstants
{
    public static class SqlServer
    {
        public static class ErrorCodes
        {
            public const int FkViolation = 547;
            public const int ConnectionError = 10061;
            public const int NotNullFieldMissing = 515;
        }
    }
}