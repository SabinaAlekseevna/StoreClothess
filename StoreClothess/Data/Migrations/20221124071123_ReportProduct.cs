using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreClothess.Data.Migrations
{
    public partial class ReportProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportProductDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SumPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SumProduct = table.Column<int>(type: "int", nullable: true),
                    StoreID = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportProductDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportProductDB_ProductDB_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductDB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportProductDB_StoreDB_StoreID",
                        column: x => x.StoreID,
                        principalTable: "StoreDB",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportProductDB_ProductId",
                table: "ReportProductDB",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportProductDB_StoreID",
                table: "ReportProductDB",
                column: "StoreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportProductDB");
        }
    }
}
