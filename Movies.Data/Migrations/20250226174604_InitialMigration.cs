using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Biography", "BirthDate", "Country", "Name", "Role" },
                values: new object[,]
                {
                    { 1L, "Thomas Jeffrey Hanks is an American actor and filmmaker. Known for both his comedic and dramatic roles, Hanks is one of the most popular and recognizable film stars worldwide.", new DateTime(1956, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "USA", "Tom Hanks", 0 },
                    { 2L, "Steven Allan Spielberg is an American film director, producer, and screenwriter. He is considered one of the founding pioneers of the New Hollywood era and one of the most popular directors and producers in film history.", new DateTime(1946, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "USA", "Steven Spielberg", 1 },
                    { 3L, "Mary Louise Streep is an American actress. Often described as the 'best actress of her generation', Streep is particularly known for her versatility and accents.", new DateTime(1949, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "USA", "Meryl Streep", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
