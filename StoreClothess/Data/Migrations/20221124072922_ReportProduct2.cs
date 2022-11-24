using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreClothess.Data.Migrations
{
    public partial class ReportProduct2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportProductDB_ProductDB_ProductId",
                table: "ReportProductDB");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ReportProductDB",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ReportProductDB_ProductId",
                table: "ReportProductDB",
                newName: "IX_ReportProductDB_ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportProductDB_ProductDB_ProductID",
                table: "ReportProductDB",
                column: "ProductID",
                principalTable: "ProductDB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportProductDB_ProductDB_ProductID",
                table: "ReportProductDB");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ReportProductDB",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportProductDB_ProductID",
                table: "ReportProductDB",
                newName: "IX_ReportProductDB_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportProductDB_ProductDB_ProductId",
                table: "ReportProductDB",
                column: "ProductId",
                principalTable: "ProductDB",
                principalColumn: "Id");
        }
    }
}
