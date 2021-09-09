﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BookshelfApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OwnedBooks",
                columns: table => new
                {
                    OwnedBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedBooks", x => x.OwnedBookId);
                });

            migrationBuilder.InsertData(
                table: "OwnedBooks",
                columns: new[] { "OwnedBookId", "Author", "Genre", "Rating", "ReleaseYear", "Title" },
                values: new object[] { 1, "J. R. R. Tolkien", "High Fantasy", "Great!", 1954, "The Lord of the Rings" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnedBooks");
        }
    }
}
