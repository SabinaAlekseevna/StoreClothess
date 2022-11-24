using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreClothess.Data.Migrations
{
    public partial class ProductOrder3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDB_ProductDB_ProductID",
                table: "OrderDB");

            migrationBuilder.DropIndex(
                name: "IX_OrderDB_ProductID",
                table: "OrderDB");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "OrderDB");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "OrderDB",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDB_ProductID",
                table: "OrderDB",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDB_ProductDB_ProductID",
                table: "OrderDB",
                column: "ProductID",
                principalTable: "ProductDB",
                principalColumn: "Id");
        }
    }
}
