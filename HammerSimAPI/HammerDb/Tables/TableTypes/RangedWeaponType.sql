CREATE TYPE [dbo].[RangedWeaponType] AS TABLE
(
	[Name] NVARCHAR(150) NOT NULL,
	[Range] INT NOT NULL,
	[NumOfWeapons] INT NOT NULL,
	[Attacks] INT NOT NULL,
	[WeaponSkill] INT NOT NULL,
	[Strength] INT NOT NULL,
	[AP] INT NOT NULL,
	[Damage] INT NOT NULL
);
