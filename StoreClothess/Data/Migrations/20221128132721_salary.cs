using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreClothess.Data.Migrations
{
    public partial class salary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Stores",
                table: "StoreDB",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "StoreDB",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "StoreDB",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "Times",
                table: "SellerCashierDB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "SellerCashierDB",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "ProductDB",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductDB",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Colour",
                table: "ProductDB",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "Times",
                table: "DirectorDB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "DirectorDB",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Times",
                table: "BookkeeperDB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "BookkeeperDB",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Times",
                table: "AdministratorDB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "AdministratorDB",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Times",
                table: "SellerCashierDB");

            migrationBuilder.DropColumn(
                name: "price",
                table: "SellerCashierDB");

            migrationBuilder.DropColumn(
                name: "Times",
                table: "DirectorDB");

            migrationBuilder.DropColumn(
                name: "price",
                table: "DirectorDB");

            migrationBuilder.DropColumn(
                name: "Times",
                table: "BookkeeperDB");

            migrationBuilder.DropColumn(
                name: "price",
                table: "BookkeeperDB");

            migrationBuilder.DropColumn(
                name: "Times",
                table: "AdministratorDB");

            migrationBuilder.DropColumn(
                name: "price",
                table: "AdministratorDB");

            migrationBuilder.AlterColumn<string>(
                name: "Stores",
                table: "StoreDB",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "StoreDB",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "StoreDB",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "ProductDB",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductDB",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Colour",
                table: "ProductDB",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
