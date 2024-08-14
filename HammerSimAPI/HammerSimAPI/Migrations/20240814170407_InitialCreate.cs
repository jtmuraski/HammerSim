using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HammerSimAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShootingResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShootingResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Faction = table.Column<int>(type: "INTEGER", nullable: false),
                    SubFaction = table.Column<int>(type: "INTEGER", nullable: false),
                    ModelCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Movement = table.Column<int>(type: "INTEGER", nullable: false),
                    Toughness = table.Column<int>(type: "INTEGER", nullable: false),
                    Save = table.Column<int>(type: "INTEGER", nullable: false),
                    InvulnerableSave = table.Column<int>(type: "INTEGER", nullable: false),
                    Wounds = table.Column<int>(type: "INTEGER", nullable: false),
                    Leasership = table.Column<int>(type: "INTEGER", nullable: false),
                    ObjectiveControl = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitKeywords = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeleeWeapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UnitId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeleeWeapon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeleeWeapon_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RangedWeapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Range = table.Column<int>(type: "INTEGER", nullable: false),
                    NumOfWeapons = table.Column<int>(type: "INTEGER", nullable: false),
                    Attacks = table.Column<int>(type: "INTEGER", nullable: false),
                    WeaponSkill = table.Column<int>(type: "INTEGER", nullable: false),
                    Strength = table.Column<int>(type: "INTEGER", nullable: false),
                    AP = table.Column<int>(type: "INTEGER", nullable: false),
                    Damage = table.Column<int>(type: "INTEGER", nullable: false),
                    WeaponKeywords = table.Column<string>(type: "TEXT", nullable: false),
                    ShootingResultsId = table.Column<int>(type: "INTEGER", nullable: true),
                    UnitId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangedWeapon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RangedWeapon_ShootingResults_ShootingResultsId",
                        column: x => x.ShootingResultsId,
                        principalTable: "ShootingResults",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RangedWeapon_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Wargear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UnitId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wargear", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wargear_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RangedWeaponResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeaponId = table.Column<int>(type: "INTEGER", nullable: false),
                    ShotsFired = table.Column<int>(type: "INTEGER", nullable: false),
                    Hits = table.Column<int>(type: "INTEGER", nullable: false),
                    Wounds = table.Column<int>(type: "INTEGER", nullable: false),
                    Saves = table.Column<int>(type: "INTEGER", nullable: false),
                    ModelsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    ShootingResultsId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangedWeaponResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RangedWeaponResult_RangedWeapon_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "RangedWeapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RangedWeaponResult_ShootingResults_ShootingResultsId",
                        column: x => x.ShootingResultsId,
                        principalTable: "ShootingResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeleeWeapon_UnitId",
                table: "MeleeWeapon",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RangedWeapon_ShootingResultsId",
                table: "RangedWeapon",
                column: "ShootingResultsId");

            migrationBuilder.CreateIndex(
                name: "IX_RangedWeapon_UnitId",
                table: "RangedWeapon",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RangedWeaponResult_ShootingResultsId",
                table: "RangedWeaponResult",
                column: "ShootingResultsId");

            migrationBuilder.CreateIndex(
                name: "IX_RangedWeaponResult_WeaponId",
                table: "RangedWeaponResult",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Wargear_UnitId",
                table: "Wargear",
                column: "UnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeleeWeapon");

            migrationBuilder.DropTable(
                name: "RangedWeaponResult");

            migrationBuilder.DropTable(
                name: "Wargear");

            migrationBuilder.DropTable(
                name: "RangedWeapon");

            migrationBuilder.DropTable(
                name: "ShootingResults");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
