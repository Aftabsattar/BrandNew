using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curate.Infrastructre.Migrations
{
    /// <inheritdoc />
    public partial class Updateusertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Passcode",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PasscodeCreatedAt",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Passcode",
                table: "users");

            migrationBuilder.DropColumn(
                name: "PasscodeCreatedAt",
                table: "users");
        }
    }
}
