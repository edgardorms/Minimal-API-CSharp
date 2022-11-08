using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Minimal_API.Migrations
{
    public partial class ColumnPointsTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Task");
        }
    }
}
