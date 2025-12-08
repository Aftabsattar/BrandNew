using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curate.Infrastructre.Migrations
{
    /// <inheritdoc />
    public partial class updateIdeaProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id",
                table: "ideaProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "ideaProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
