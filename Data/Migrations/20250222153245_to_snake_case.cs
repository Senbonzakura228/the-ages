using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class to_snake_case : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityBuilding_buildings_BuildingId",
                table: "CityBuilding");

            migrationBuilder.DropForeignKey(
                name: "FK_CityBuilding_userCityMaps_UserCityMapId",
                table: "CityBuilding");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCityExtension_CityExtension_CityExtensionId",
                table: "UserCityExtension");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCityExtension_userCityMaps_CityMapId",
                table: "UserCityExtension");

            migrationBuilder.DropForeignKey(
                name: "FK_userCityMaps_userGameData_Id",
                table: "userCityMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_userGameData_userAccounts_Id",
                table: "userGameData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userGameData",
                table: "userGameData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userCityMaps",
                table: "userCityMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCityExtension",
                table: "UserCityExtension");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userAccounts",
                table: "userAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityExtension",
                table: "CityExtension");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityBuilding",
                table: "CityBuilding");

            migrationBuilder.RenameTable(
                name: "userGameData",
                newName: "user_game_data");

            migrationBuilder.RenameTable(
                name: "userCityMaps",
                newName: "user_city_maps");

            migrationBuilder.RenameTable(
                name: "UserCityExtension",
                newName: "user_city_extension");

            migrationBuilder.RenameTable(
                name: "userAccounts",
                newName: "user_accounts");

            migrationBuilder.RenameTable(
                name: "CityExtension",
                newName: "city_extension");

            migrationBuilder.RenameTable(
                name: "CityBuilding",
                newName: "city_building");

            migrationBuilder.RenameIndex(
                name: "IX_UserCityExtension_CityExtensionId",
                table: "user_city_extension",
                newName: "IX_user_city_extension_CityExtensionId");

            migrationBuilder.RenameIndex(
                name: "IX_CityBuilding_BuildingId",
                table: "city_building",
                newName: "IX_city_building_BuildingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_game_data",
                table: "user_game_data",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_city_maps",
                table: "user_city_maps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_city_extension",
                table: "user_city_extension",
                columns: new[] { "CityMapId", "CityExtensionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_accounts",
                table: "user_accounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_city_extension",
                table: "city_extension",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_city_building",
                table: "city_building",
                columns: new[] { "UserCityMapId", "BuildingId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_city_building_buildings_BuildingId",
                table: "city_building",
                column: "BuildingId",
                principalTable: "buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_city_building_user_city_maps_UserCityMapId",
                table: "city_building",
                column: "UserCityMapId",
                principalTable: "user_city_maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_city_extension_city_extension_CityExtensionId",
                table: "user_city_extension",
                column: "CityExtensionId",
                principalTable: "city_extension",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_city_extension_user_city_maps_CityMapId",
                table: "user_city_extension",
                column: "CityMapId",
                principalTable: "user_city_maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_city_maps_user_game_data_Id",
                table: "user_city_maps",
                column: "Id",
                principalTable: "user_game_data",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_game_data_user_accounts_Id",
                table: "user_game_data",
                column: "Id",
                principalTable: "user_accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_city_building_buildings_BuildingId",
                table: "city_building");

            migrationBuilder.DropForeignKey(
                name: "FK_city_building_user_city_maps_UserCityMapId",
                table: "city_building");

            migrationBuilder.DropForeignKey(
                name: "FK_user_city_extension_city_extension_CityExtensionId",
                table: "user_city_extension");

            migrationBuilder.DropForeignKey(
                name: "FK_user_city_extension_user_city_maps_CityMapId",
                table: "user_city_extension");

            migrationBuilder.DropForeignKey(
                name: "FK_user_city_maps_user_game_data_Id",
                table: "user_city_maps");

            migrationBuilder.DropForeignKey(
                name: "FK_user_game_data_user_accounts_Id",
                table: "user_game_data");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_game_data",
                table: "user_game_data");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_city_maps",
                table: "user_city_maps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_city_extension",
                table: "user_city_extension");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_accounts",
                table: "user_accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_city_extension",
                table: "city_extension");

            migrationBuilder.DropPrimaryKey(
                name: "PK_city_building",
                table: "city_building");

            migrationBuilder.RenameTable(
                name: "user_game_data",
                newName: "userGameData");

            migrationBuilder.RenameTable(
                name: "user_city_maps",
                newName: "userCityMaps");

            migrationBuilder.RenameTable(
                name: "user_city_extension",
                newName: "UserCityExtension");

            migrationBuilder.RenameTable(
                name: "user_accounts",
                newName: "userAccounts");

            migrationBuilder.RenameTable(
                name: "city_extension",
                newName: "CityExtension");

            migrationBuilder.RenameTable(
                name: "city_building",
                newName: "CityBuilding");

            migrationBuilder.RenameIndex(
                name: "IX_user_city_extension_CityExtensionId",
                table: "UserCityExtension",
                newName: "IX_UserCityExtension_CityExtensionId");

            migrationBuilder.RenameIndex(
                name: "IX_city_building_BuildingId",
                table: "CityBuilding",
                newName: "IX_CityBuilding_BuildingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userGameData",
                table: "userGameData",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userCityMaps",
                table: "userCityMaps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCityExtension",
                table: "UserCityExtension",
                columns: new[] { "CityMapId", "CityExtensionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_userAccounts",
                table: "userAccounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityExtension",
                table: "CityExtension",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityBuilding",
                table: "CityBuilding",
                columns: new[] { "UserCityMapId", "BuildingId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_CityBuilding_buildings_BuildingId",
                table: "CityBuilding",
                column: "BuildingId",
                principalTable: "buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CityBuilding_userCityMaps_UserCityMapId",
                table: "CityBuilding",
                column: "UserCityMapId",
                principalTable: "userCityMaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCityExtension_CityExtension_CityExtensionId",
                table: "UserCityExtension",
                column: "CityExtensionId",
                principalTable: "CityExtension",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCityExtension_userCityMaps_CityMapId",
                table: "UserCityExtension",
                column: "CityMapId",
                principalTable: "userCityMaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userCityMaps_userGameData_Id",
                table: "userCityMaps",
                column: "Id",
                principalTable: "userGameData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userGameData_userAccounts_Id",
                table: "userGameData",
                column: "Id",
                principalTable: "userAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
