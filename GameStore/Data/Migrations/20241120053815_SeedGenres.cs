using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.data.Migrations
{
    /// <inheritdoc />
    public partial class SeedGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GGenres",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Fighting" },
                    { 2, "Sports" },
                    { 3, "Racing" },
                    { 4, "RP" },
                    { 5, "Family" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GGenres",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GGenres",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GGenres",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GGenres",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GGenres",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
