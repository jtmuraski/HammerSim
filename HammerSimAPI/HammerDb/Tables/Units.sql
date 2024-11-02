CREATE TABLE [dbo].[Units]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(150) NOT NULL,
	[Faction] NVARCHAR(150) NOT NULL,
	[SubFaction] NVARCHAR(150) NOT NULL,
	[ModelCount] INT NOT NULL,
	[Movement] INT NOT NULL,
	[Toughness] INT NOT NULL,
	ArmorSave INT NOT NULL,
	[InvulnerableSave] INT NOT NULL,
	[Wounds] INT NOT NULL,
	[Leadership] INT NOT NULL,
	[ObjectiveControl] INT NULL
)
