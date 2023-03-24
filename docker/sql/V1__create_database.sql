/* Create the hexarch database if it doesn't exist */
IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE name = 'hexarch')
BEGIN
    CREATE DATABASE hexarch;
END
GO

/* Use the hexarch database */
USE hexarch;
GO

/* Create the person table if it doesn't exist */
IF NOT EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[person]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[person] (
    [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] VARCHAR(200) NOT NULL,
    [BirthDate] DATETIME NOT NULL
    );
END
GO
