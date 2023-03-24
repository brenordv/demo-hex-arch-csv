using Raccoon.Ninja.Extensions.Common;

namespace HexArch.Csv.Repositories.Queries;

public static class PersonQueries
{
    public static class Queries
    {
        public static readonly string SelectAll = @"
                SELECT 
                    Id AS [Id],
                    Name AS [Name],
                    BirthDate AS [BirthDate]
                FROM person".Minify();
        
        public static readonly string Insert = @"
                INSERT INTO person (Name, BirthDate)
                VALUES (@Name, @BirthDate)".Minify();
        
    }
}