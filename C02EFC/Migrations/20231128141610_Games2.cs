using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace C02EFC.Migrations
{
    /// <inheritdoc />
    public partial class Games2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Name" },
                values: new object[] { 3, "Obsidian" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 2,
                columns: new[] { "DeveloperId", "Name" },
                values: new object[] { 2, "Skyrim" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "DeveloperId", "Name" },
                values: new object[,]
                {
                    { 3, 2, "Fallout 4" },
                    { 4, 2, "Starfield" },
                    { 5, 2, "Oblivion" },
                    { 6, 3, "Outer Worlds" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 2,
                columns: new[] { "DeveloperId", "Name" },
                values: new object[] { 1, "Witcher 3" });
        }
    }
}
