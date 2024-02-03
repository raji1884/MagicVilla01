using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVillaVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "villamodels",
                columns: new[] { "Id", "Amenity", "Details", "ImageUrl", "Name", "Rate", "occupancy", "sqft" },
                values: new object[,]
                {
                    { 1, "", "good", "", "heart villa", 690.0, 5, 520 },
                    { 2, "", "good", "", "modern villa", 300.0, 6, 740 },
                    { 3, "", "good", "", "lovely villa", 100.0, 5, 340 },
                    { 4, "", "good", "", "sweet villa", 300.0, 5, 640 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "villamodels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "villamodels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "villamodels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "villamodels",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
