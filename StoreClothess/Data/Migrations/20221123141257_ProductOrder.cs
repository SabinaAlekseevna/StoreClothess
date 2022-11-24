using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreClothess.Data.Migrations
{
    public partial class ProductOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderProductDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductStoreOrderId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProductDB_ProductDB_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrdDB",
                columns: table => new
                {
                    ProductOrdId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrdDB", x => x.ProductOrdId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductDB_ProductId",
                table: "OrderProductDB",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProductDB");

            migrationBuilder.DropTable(
                name: "ProductOrdDB");
        }
    }
}
