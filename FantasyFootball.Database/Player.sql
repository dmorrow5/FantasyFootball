CREATE TABLE [dbo].[Player]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NCHAR(10) NULL, 
	[Team] UNIQUEIDENTIFIER NOT NULL, 
    [Position] INT NULL, 
    [GP] INT NULL, 
	[Bye] INT NULL, 
    [Fan Pts] FLOAT NULL, 
    [PassingYards] INT NULL, 
    [RushingYards] INT NULL, 
    [ReceivingYards] INT NULL, 
    [Fumbles] INT NULL, 
    CONSTRAINT [FK_Player_ToPSportsTeam] FOREIGN KEY (Team) REFERENCES [SportsTeam]([Id])
)
