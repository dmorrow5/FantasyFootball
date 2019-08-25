CREATE TABLE [dbo].[SportsTeam]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NCHAR(10) NULL, 
    [Points] INT NULL, 
	[Wins] INT NULL, 
    [Losses] INT NULL, 
    [Ties] INT NULL
)
