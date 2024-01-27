using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    secondaryTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "Slug", "Title", "secondaryTitle" },
                values: new object[] { 1, "grant", "dkwqdlwqdlqw", new DateTime(2024, 1, 27, 13, 37, 31, 289, DateTimeKind.Utc).AddTicks(5080), "what-biden-did", "sdqdwq", "what biden did" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "Slug", "Title", "secondaryTitle" },
                values: new object[] { 2, "grant", "dkwqdlwqdlqw", new DateTime(2024, 1, 27, 13, 37, 31, 289, DateTimeKind.Utc).AddTicks(5080), "what-biden-did", "wrfqwr", "what biden did" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "Slug", "Title", "secondaryTitle" },
                values: new object[] { 3, "grant", "dkwqdlwqdlqw", new DateTime(2024, 1, 27, 13, 37, 31, 289, DateTimeKind.Utc).AddTicks(5090), "what-biden-did", "fewfwe", "what biden did" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
