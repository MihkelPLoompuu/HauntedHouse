using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HauntedHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class sa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingType = table.Column<int>(type: "int", nullable: false),
                    RoomIDs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlayerProfiles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScreenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HunterCredits = table.Column<int>(type: "int", nullable: false),
                    Victories = table.Column<int>(type: "int", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    MyBuildings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentStatus = table.Column<int>(type: "int", nullable: false),
                    ProfileType = table.Column<bool>(type: "bit", nullable: false),
                    ProfileCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileAttributedToAnAccountUserAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileStatusLastChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerProfiles", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "PlayerProfiles");
        }
    }
}
