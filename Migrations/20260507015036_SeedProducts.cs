using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppCrud.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Name", "Price", "Sku", "Stock" },
                values: new object[,]
                {
                    { 1, "Tecnología", "Mouse Gamer", 150000m, "SKU-001", 10 },
                    { 2, "Tecnología", "Teclado Mecánico", 250000m, "SKU-002", 5 },
                    { 3, "Tecnología", "Monitor 24", 800000m, "SKU-003", 7 },
                    { 4, "Audio", "Audífonos", 120000m, "SKU-004", 15 },
                    { 5, "Muebles", "Silla Gamer", 950000m, "SKU-005", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
