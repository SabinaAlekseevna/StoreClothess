using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreClothess.Data.Migrations
{
    public partial class RemoveOnlineCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdministratorDB_StoreDB_storeID",
                table: "AdministratorDB");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerCashierDB_StoreDB_storeID",
                table: "SellerCashierDB");

            migrationBuilder.RenameColumn(
                name: "storeID",
                table: "SellerCashierDB",
                newName: "StoreID");

            migrationBuilder.RenameIndex(
                name: "IX_SellerCashierDB_storeID",
                table: "SellerCashierDB",
                newName: "IX_SellerCashierDB_StoreID");

            migrationBuilder.RenameColumn(
                name: "storeID",
                table: "AdministratorDB",
                newName: "StoreID");

            migrationBuilder.RenameIndex(
                name: "IX_AdministratorDB_storeID",
                table: "AdministratorDB",
                newName: "IX_AdministratorDB_StoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_AdministratorDB_StoreDB_StoreID",
                table: "AdministratorDB",
                column: "StoreID",
                principalTable: "StoreDB",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SellerCashierDB_StoreDB_StoreID",
                table: "SellerCashierDB",
                column: "StoreID",
                principalTable: "StoreDB",
                principalColumn: "Id");

            migrationBuilder.DropForeignKey(
         name: "FK_ProductDB_StoreDB_StoreId",
         table: "ProductDB");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDB_StoreDB_StoreId",
                table: "ProductDB",
                column: "StoreId",
                principalTable: "StoreDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdministratorDB_StoreDB_StoreID",
                table: "AdministratorDB");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerCashierDB_StoreDB_StoreID",
                table: "SellerCashierDB");

            migrationBuilder.RenameColumn(
                name: "StoreID",
                table: "SellerCashierDB",
                newName: "storeID");

            migrationBuilder.RenameIndex(
                name: "IX_SellerCashierDB_StoreID",
                table: "SellerCashierDB",
                newName: "IX_SellerCashierDB_storeID");

            migrationBuilder.RenameColumn(
                name: "StoreID",
                table: "AdministratorDB",
                newName: "storeID");

            migrationBuilder.RenameIndex(
                name: "IX_AdministratorDB_StoreID",
                table: "AdministratorDB",
                newName: "IX_AdministratorDB_storeID");

            migrationBuilder.AddForeignKey(
                name: "FK_AdministratorDB_StoreDB_storeID",
                table: "AdministratorDB",
                column: "storeID",
                principalTable: "StoreDB",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SellerCashierDB_StoreDB_storeID",
                table: "SellerCashierDB",
                column: "storeID",
                principalTable: "StoreDB",
                principalColumn: "Id");


            migrationBuilder.DropForeignKey(
                name: "FK_ProductDB_StoreDB_StoreId",
                table: "ProductDB");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDB_StoreDB_StoreId",
                table: "ProductDB",
                column: "StoreId",
                principalTable: "StoreDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
