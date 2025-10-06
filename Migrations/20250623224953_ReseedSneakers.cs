using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SneakerStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class ReseedSneakers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "https://cdn.flightclub.com/TEMPLATE/307016/1.jpg?w=1920", 300m });

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/TEMPLATE/253215/1.jpg?w=1920");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/TEMPLATE/368573/1.jpg?w=1920");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/TEMPLATE/371711/1.jpg?w=1920");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/TEMPLATE/460574/1.jpg?w=1920");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/TEMPLATE/397161/1.jpg?w=1920");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/TEMPLATE/301688/1.jpg?w=1920");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/TEMPLATE/363222/1.jpg?w=1920");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/TEMPLATE/389891/1.jpg?w=1920");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/TEMPLATE/350502/1.jpg?w=1920");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Brand", "ImageUrl", "Name" },
                values: new object[] { "New Balance", "https://cdn.flightclub.com/TEMPLATE/350162/1.jpg?w=1920", "New Balance 2002R" });

            migrationBuilder.InsertData(
                table: "Sneakers",
                columns: new[] { "Id", "Brand", "ImageUrl", "Name", "Price" },
                values: new object[] { 13, "Jordan", "https://cdn.flightclub.com/TEMPLATE/011502/1.jpg?w=1920", "Retro Cement 3", 300m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "https://unsplash.com/photos/blue-and-black-nike-high-top-sneakers-BWPqHZBhMVA", 150m });

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/750/TEMPLATE/251302/1.jpg");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/750/TEMPLATE/803758/1.jpg");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/750/TEMPLATE/804727/1.jpg");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/750/TEMPLATE/265818/1.jpg");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/750/TEMPLATE/804728/1.jpg");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/750/TEMPLATE/804729/1.jpg");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/750/TEMPLATE/804730/1.jpg");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/750/TEMPLATE/804731/1.jpg");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/750/TEMPLATE/804732/1.jpg");

            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Brand", "ImageUrl", "Name" },
                values: new object[] { "On", "https://cdn.flightclub.com/750/TEMPLATE/804733/1.jpg", "On Cloudnova" });
        }
    }
}
