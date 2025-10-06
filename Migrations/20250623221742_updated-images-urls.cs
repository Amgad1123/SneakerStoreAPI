using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SneakerStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatedimagesurls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://unsplash.com/photos/blue-and-black-nike-high-top-sneakers-BWPqHZBhMVA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sneakers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://cdn.flightclub.com/750/TEMPLATE/805078/1.jpg");
        }
    }
}
