using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreClothess.Data.Migrations
{
    public partial class ReportProduct3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDB_StoreDB_StoreId",
                table: "ProductDB");

            migrationBuilder.DropTable(
                name: "ReportProductDB");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "ProductDB",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDB_StoreDB_StoreId",
                table: "ProductDB",
                column: "StoreId",
                principalTable: "StoreDB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDB_StoreDB_StoreId",
                table: "ProductDB");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "ProductDB",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ReportProductDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    StoreID = table.Column<int>(type: "int", nullable: true),
                    SumPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SumProduct = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportProductDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportProductDB_ProductDB_ProductID",
                        column: x => x.ProductID,
                        principalTable: "ProductDB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportProductDB_StoreDB_StoreID",
                        column: x => x.StoreID,
                        principalTable: "StoreDB",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportProductDB_ProductID",
                table: "ReportProductDB",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportProductDB_StoreID",
                table: "ReportProductDB",
                column: "StoreID");

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
