using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HauntedHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class nk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ProfileType",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileType",
                table: "AspNetUsers");
        }
    }
}
