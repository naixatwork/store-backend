using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    public partial class Customerfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Customers_Customerid",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_Customerid",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Customerid",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "Customerid",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Customerid",
                table: "Products",
                column: "Customerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Customers_Customerid",
                table: "Products",
                column: "Customerid",
                principalTable: "Customers",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Customers_Customerid",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Customerid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Customerid",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Customerid",
                table: "Customers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Customerid",
                table: "Customers",
                column: "Customerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Customers_Customerid",
                table: "Customers",
                column: "Customerid",
                principalTable: "Customers",
                principalColumn: "id");
        }
    }
}
