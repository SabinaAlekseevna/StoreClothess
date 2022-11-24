using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreClothess.Data.Migrations
{
    public partial class ReportEmployees1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StoreDB_StoreId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StoreId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Employee",
                table: "SellerCashierDB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Employee",
                table: "DirectorDB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Employee",
                table: "BookkeeperDB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Employee",
                table: "AdministratorDB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Employee",
                table: "SellerCashierDB");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "DirectorDB");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "BookkeeperDB");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "AdministratorDB");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StoreId",
                table: "AspNetUsers",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StoreDB_StoreId",
                table: "AspNetUsers",
                column: "StoreId",
                principalTable: "StoreDB",
                principalColumn: "Id");
        }
    }
}
