using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class buildingplacement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    width = table.Column<int>(type: "integer", nullable: false),
                    height = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityExtension",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    XCoordinate = table.Column<int>(type: "integer", nullable: false),
                    YCoordinate = table.Column<int>(type: "integer", nullable: false),
                    width = table.Column<int>(type: "integer", nullable: false),
                    height = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityExtension", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userGameData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userGameData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userGameData_userAccounts_Id",
                        column: x => x.Id,
                        principalTable: "userAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userCityMaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userCityMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userCityMaps_userGameData_Id",
                        column: x => x.Id,
                        principalTable: "userGameData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityBuilding",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    UserCityMapId = table.Column<int>(type: "integer", nullable: false),
                    BuildingId = table.Column<int>(type: "integer", nullable: false),
                    XCoordinate = table.Column<int>(type: "integer", nullable: false),
                    YCoordinate = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityBuilding", x => new { x.UserCityMapId, x.BuildingId, x.Id });
                    table.ForeignKey(
                        name: "FK_CityBuilding_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityBuilding_userCityMaps_UserCityMapId",
                        column: x => x.UserCityMapId,
                        principalTable: "userCityMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCityExtension",
                columns: table => new
                {
                    CityMapId = table.Column<int>(type: "integer", nullable: false),
                    CityExtensionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCityExtension", x => new { x.CityMapId, x.CityExtensionId });
                    table.ForeignKey(
                        name: "FK_UserCityExtension_CityExtension_CityExtensionId",
                        column: x => x.CityExtensionId,
                        principalTable: "CityExtension",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCityExtension_userCityMaps_CityMapId",
                        column: x => x.CityMapId,
                        principalTable: "userCityMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CityExtension",
                columns: new[] { "Id", "XCoordinate", "YCoordinate", "height", "width" },
                values: new object[] { 1, -15, 0, 15, 15 });

            migrationBuilder.InsertData(
                table: "buildings",
                columns: new[] { "Id", "Name", "height", "width" },
                values: new object[] { 1, "StoneAgeHouse", 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_CityBuilding_BuildingId",
                table: "CityBuilding",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCityExtension_CityExtensionId",
                table: "UserCityExtension",
                column: "CityExtensionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityBuilding");

            migrationBuilder.DropTable(
                name: "UserCityExtension");

            migrationBuilder.DropTable(
                name: "buildings");

            migrationBuilder.DropTable(
                name: "CityExtension");

            migrationBuilder.DropTable(
                name: "userCityMaps");

            migrationBuilder.DropTable(
                name: "userGameData");

            migrationBuilder.DropTable(
                name: "userAccounts");
        }
    }
}
