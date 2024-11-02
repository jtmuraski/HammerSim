CREATE TABLE [dbo].[RangedWeapons]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UnitId] INT NOT NULL FOREIGN KEY REFERENCES Units(Id),
	[Name] NVARCHAR(150) NOT NULL,
	[Range] INT NOT NULL,
	[NumOfWeapons] INT NOT NULL,
	[Attacks] INT NOT NULL,
	[WeaponSkill] INT NOT NULL,
	[Strength] INT NOT NULL,
	[AP] INT NOT NULL,
	[Damage] INT NOT NULL
)
