using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curate.Infrastructre.Migrations
{
    /// <inheritdoc />
    public partial class updateuserregisterentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Passcode",
                table: "users");

            migrationBuilder.AddColumn<bool>(
                name: "IsProfileCompleted",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProfileCompleted",
                table: "users");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "Passcode",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
