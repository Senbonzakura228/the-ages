using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userDivide : Migration
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
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "city_extension",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    XCoordinate = table.Column<int>(type: "integer", nullable: false),
                    YCoordinate = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city_extension", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_city_maps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_city_maps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "city_building",
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
                    table.PrimaryKey("PK_city_building", x => new { x.UserCityMapId, x.BuildingId, x.Id });
                    table.ForeignKey(
                        name: "FK_city_building_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_city_building_user_city_maps_UserCityMapId",
                        column: x => x.UserCityMapId,
                        principalTable: "user_city_maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_city_extension",
                columns: table => new
                {
                    CityMapId = table.Column<int>(type: "integer", nullable: false),
                    CityExtensionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_city_extension", x => new { x.CityMapId, x.CityExtensionId });
                    table.ForeignKey(
                        name: "FK_user_city_extension_city_extension_CityExtensionId",
                        column: x => x.CityExtensionId,
                        principalTable: "city_extension",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_city_extension_user_city_maps_CityMapId",
                        column: x => x.CityMapId,
                        principalTable: "user_city_maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "buildings",
                columns: new[] { "Id", "Height", "Name", "Width" },
                values: new object[] { 1, 2, "StoneAgeHouse", 2 });

            migrationBuilder.InsertData(
                table: "city_extension",
                columns: new[] { "Id", "Height", "Width", "XCoordinate", "YCoordinate" },
                values: new object[] { 1, 15, 15, -15, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_city_building_BuildingId",
                table: "city_building",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_user_city_extension_CityExtensionId",
                table: "user_city_extension",
                column: "CityExtensionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "city_building");

            migrationBuilder.DropTable(
                name: "user_city_extension");

            migrationBuilder.DropTable(
                name: "buildings");

            migrationBuilder.DropTable(
                name: "city_extension");

            migrationBuilder.DropTable(
                name: "user_city_maps");
        }
    }
}
