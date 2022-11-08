using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Minimal_API.Migrations
{
    public partial class ColumnAreaCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Area",
                table: "Categoria",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Categoria");
        }
    }
}
