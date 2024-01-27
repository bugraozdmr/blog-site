using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageMain",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageSecondary",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageMain", "ImageSecondary" },
                values: new object[] { new DateTime(2024, 1, 27, 13, 41, 9, 245, DateTimeKind.Utc).AddTicks(1380), "#", "#" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageMain", "ImageSecondary" },
                values: new object[] { new DateTime(2024, 1, 27, 13, 41, 9, 245, DateTimeKind.Utc).AddTicks(1380), "#", "#" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageMain", "ImageSecondary" },
                values: new object[] { new DateTime(2024, 1, 27, 13, 41, 9, 245, DateTimeKind.Utc).AddTicks(1380), "#", "#" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageMain",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImageSecondary",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 27, 13, 37, 31, 289, DateTimeKind.Utc).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 27, 13, 37, 31, 289, DateTimeKind.Utc).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 27, 13, 37, 31, 289, DateTimeKind.Utc).AddTicks(5090));
        }
    }
}
