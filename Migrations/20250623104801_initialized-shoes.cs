using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SneakerStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class initializedshoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Sneakers",
                columns: new[] { "Id", "Brand", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Jordan", "https://cdn.flightclub.com/750/TEMPLATE/805078/1.jpg", "Air Jordan 1", 150m },
                    { 2, "Nike", "https://cdn.flightclub.com/750/TEMPLATE/251302/1.jpg", "Nike Dunk Low", 120m },
                    { 3, "Adidas", "https://cdn.flightclub.com/750/TEMPLATE/803758/1.jpg", "Yeezy Boost 350", 200m },
                    { 4, "New Balance", "https://cdn.flightclub.com/750/TEMPLATE/804727/1.jpg", "New Balance 550", 110m },
                    { 5, "Adidas", "https://cdn.flightclub.com/750/TEMPLATE/265818/1.jpg", "Adidas Samba OG", 90m },
                    { 7, "Puma", "https://cdn.flightclub.com/750/TEMPLATE/804728/1.jpg", "Puma RS-X", 100m },
                    { 8, "Converse", "https://cdn.flightclub.com/750/TEMPLATE/804729/1.jpg", "Converse Chuck 70", 75m },
                    { 9, "Reebok", "https://cdn.flightclub.com/750/TEMPLATE/804730/1.jpg", "Reebok Club C 85", 85m },
                    { 10, "Asics", "https://cdn.flightclub.com/750/TEMPLATE/804731/1.jpg", "Asics Gel-Lyte III", 95m },
                    { 11, "Vans", "https://cdn.flightclub.com/750/TEMPLATE/804732/1.jpg", "Vans Old Skool", 70m },
                    { 12, "On", "https://cdn.flightclub.com/750/TEMPLATE/804733/1.jpg", "On Cloudnova", 160m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Customer");
        }
    }
}
