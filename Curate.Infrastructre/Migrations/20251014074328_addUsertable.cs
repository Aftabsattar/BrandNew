using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curate.Infrastructre.Migrations
{
    /// <inheritdoc />
    public partial class addUsertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Passcode",
                table: "profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passcode = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdateAt = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "profiles");

            migrationBuilder.DropColumn(
                name: "Passcode",
                table: "profiles");
        }
    }
}
