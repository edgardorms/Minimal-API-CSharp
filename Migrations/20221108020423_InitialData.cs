using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Minimal_API.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoryId", "Area", "Description", "Effort", "Name" },
                values: new object[] { new Guid("6fc268ea-c5fe-4ffb-986c-389e196a0763"), 1, null, 50, "actividades pendientes" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "DateTimeCreated", "Description", "Points", "Stars", "TaskPriority", "Title" },
                values: new object[] { new Guid("6fc268ea-c5fe-4ffb-986c-389e196a0565"), new Guid("6fc268ea-c5fe-4ffb-986c-389e196a0763"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 20, 4, 0, "tarea 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("6fc268ea-c5fe-4ffb-986c-389e196a0565"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoryId",
                keyValue: new Guid("6fc268ea-c5fe-4ffb-986c-389e196a0763"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
