using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SneakerStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class reseeddatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Sneakers",
                columns: new[] { "Id", "Brand", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 14, "Jordan", "https://cdn.flightclub.com/TEMPLATE/307016/1.jpg?w=1920", "Air Jordan 1", 300m },
                    { 15, "Nike", "https://cdn.flightclub.com/TEMPLATE/253215/1.jpg?w=1920", "Nike Dunk Low", 120m },
                    { 16, "Adidas", "https://cdn.flightclub.com/TEMPLATE/368573/1.jpg?w=1920", "Yeezy Boost 350", 200m },
                    { 17, "New Balance", "https://cdn.flightclub.com/TEMPLATE/371711/1.jpg?w=1920", "New Balance 550", 110m },
                    { 18, "Adidas", "https://cdn.flightclub.com/TEMPLATE/460574/1.jpg?w=1920", "Adidas Samba OG", 90m },
                    { 19, "Puma", "https://cdn.flightclub.com/TEMPLATE/397161/1.jpg?w=1920", "Puma RS-X", 100m },
                    { 20, "Converse", "https://cdn.flightclub.com/TEMPLATE/301688/1.jpg?w=1920", "Converse Chuck 70", 75m },
                    { 21, "Reebok", "https://cdn.flightclub.com/TEMPLATE/363222/1.jpg?w=1920", "Reebok Club C 85", 85m },
                    { 22, "Asics", "https://cdn.flightclub.com/TEMPLATE/389891/1.jpg?w=1920", "Asics Gel-Lyte III", 95m },
                    { 23, "Vans", "https://cdn.flightclub.com/TEMPLATE/350502/1.jpg?w=1920", "Vans Old Skool", 70m },
                    { 24, "New Balance", "https://cdn.flightclub.com/TEMPLATE/350162/1.jpg?w=1920", "New Balance 2002R", 160m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.InsertData(
                table: "Sneakers",
                columns: new[] { "Id", "Brand", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Jordan", "https://cdn.flightclub.com/TEMPLATE/307016/1.jpg?w=1920", "Air Jordan 1", 300m },
                    { 2, "Nike", "https://cdn.flightclub.com/TEMPLATE/253215/1.jpg?w=1920", "Nike Dunk Low", 120m },
                    { 3, "Adidas", "https://cdn.flightclub.com/TEMPLATE/368573/1.jpg?w=1920", "Yeezy Boost 350", 200m },
                    { 4, "New Balance", "https://cdn.flightclub.com/TEMPLATE/371711/1.jpg?w=1920", "New Balance 550", 110m },
                    { 5, "Adidas", "https://cdn.flightclub.com/TEMPLATE/460574/1.jpg?w=1920", "Adidas Samba OG", 90m },
                    { 7, "Puma", "https://cdn.flightclub.com/TEMPLATE/397161/1.jpg?w=1920", "Puma RS-X", 100m },
                    { 8, "Converse", "https://cdn.flightclub.com/TEMPLATE/301688/1.jpg?w=1920", "Converse Chuck 70", 75m },
                    { 9, "Reebok", "https://cdn.flightclub.com/TEMPLATE/363222/1.jpg?w=1920", "Reebok Club C 85", 85m },
                    { 10, "Asics", "https://cdn.flightclub.com/TEMPLATE/389891/1.jpg?w=1920", "Asics Gel-Lyte III", 95m },
                    { 11, "Vans", "https://cdn.flightclub.com/TEMPLATE/350502/1.jpg?w=1920", "Vans Old Skool", 70m },
                    { 12, "New Balance", "https://cdn.flightclub.com/TEMPLATE/350162/1.jpg?w=1920", "New Balance 2002R", 160m }
                });
        }
    }
}
