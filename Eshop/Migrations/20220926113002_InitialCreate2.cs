using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eshop.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Basket",
                columns: new[] { "BasketID", "Name" },
                values: new object[] { 1, "StartBasket" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Type" },
                values: new object[] { "Multicooker", "Multicooker", 0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Mouse", "Mouse" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "Name",
                value: "Wire");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Type" },
                values: new object[] { "AutoWire", "AutoWire", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Basket",
                keyColumn: "BasketID",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Type" },
                values: new object[] { "Notebook", "EliteBook", 3 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Notebook", "EliteBook" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "Name",
                value: "EliteBook");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Type" },
                values: new object[] { "Notebook", "EliteBook", 3 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "BasketID", "Description", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 6, 0, "Notebook", "EliteBook", 4, 3 },
                    { 7, 0, "Notebook", "EliteBook", 4, 3 },
                    { 8, 0, "Notebook", "EliteBook", 4, 3 },
                    { 9, 0, "Notebook", "EliteBook", 4, 3 }
                });
        }
    }
}
