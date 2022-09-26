using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eshop.Migrations
{
    public partial class AddProducts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "BasketID", "Description", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 2, 0, "Notebook", "EliteBook", 4, 3 },
                    { 3, 0, "Notebook", "EliteBook", 4, 3 },
                    { 4, 0, "Notebook", "EliteBook", 4, 3 },
                    { 5, 0, "Notebook", "EliteBook", 4, 3 },
                    { 6, 0, "Notebook", "EliteBook", 4, 3 },
                    { 7, 0, "Notebook", "EliteBook", 4, 3 },
                    { 8, 0, "Notebook", "EliteBook", 4, 3 },
                    { 9, 0, "Notebook", "EliteBook", 4, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 9);
        }
    }
}
