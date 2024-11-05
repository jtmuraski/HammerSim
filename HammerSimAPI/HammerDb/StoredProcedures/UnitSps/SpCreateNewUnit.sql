-- Stored Procedure to insert a new unit into the database
-- returns the new Id in order to insert the units weapons

CREATE PROCEDURE [dbo].[SpCreateNewUnit]
	@name nvarchar,
	@faction nvarchar,
	@subFaction nvarchar,
	@modelCount int,
	@movement int,
	@toughness int,
	@armorsave int,
	@invulnerableSave int,
	@wounds int,
	@leadership int,
	@objectiveControl int,
	@RangedWeapons RangedWeaponType READONLY
AS
	INSERT INTO Units (Name, Faction, SubFaction, ModelCount, Movement, Toughness, ArmorSave, InvulnerableSave, Wounds, Leadership, ObjectiveControl)
				VALUES (@name, @faction, @subFaction, @modelCount, @movement, @toughness, @armorsave, @invulnerableSave, @wounds, @leadership, @objectiveControl);

DECLARE @UnitId INT = SCOPE_IDENTITY();

-- INSERT the units ranged weapons
INSERT INTO RangedWeapons (UnitId, 
						   Name, 
						   Range,
						   NumOfWeapons,
						   Attacks,
						   WeaponSkill,
						   Strength,
						   AP,
						   Damage)
			SELECT @UnitId,
			        Name,
					Range,
					NumOfWeapons,
					Attacks,
					WeaponSKill,
					Strength,
					AP,
					Damage FROM @RangedWeapons;

