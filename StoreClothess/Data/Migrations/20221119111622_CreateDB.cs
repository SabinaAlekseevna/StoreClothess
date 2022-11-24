using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreClothess.Data.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BookkeeperDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookkeeperDB", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookkeeperDB_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DirectorDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorDB", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DirectorDB_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StoreDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stores = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreDB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdministratorDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storeID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministratorDB", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdministratorDB_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdministratorDB_StoreDB_storeID",
                        column: x => x.storeID,
                        principalTable: "StoreDB",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Prise = table.Column<float>(type: "real", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDB_StoreDB_StoreId",
                        column: x => x.StoreId,
                        principalTable: "StoreDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellerCashierDB",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storeID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerCashierDB", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SellerCashierDB_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SellerCashierDB_StoreDB_storeID",
                        column: x => x.storeID,
                        principalTable: "StoreDB",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministratorDB_storeID",
                table: "AdministratorDB",
                column: "storeID");

            migrationBuilder.CreateIndex(
                name: "IX_AdministratorDB_UserID",
                table: "AdministratorDB",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookkeeperDB_UserID",
                table: "BookkeeperDB",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DirectorDB_UserID",
                table: "DirectorDB",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDB_StoreId",
                table: "ProductDB",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerCashierDB_storeID",
                table: "SellerCashierDB",
                column: "storeID");

            migrationBuilder.CreateIndex(
                name: "IX_SellerCashierDB_UserID",
                table: "SellerCashierDB",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministratorDB");

            migrationBuilder.DropTable(
                name: "BookkeeperDB");

            migrationBuilder.DropTable(
                name: "DirectorDB");

            migrationBuilder.DropTable(
                name: "ProductDB");

            migrationBuilder.DropTable(
                name: "SellerCashierDB");

            migrationBuilder.DropTable(
                name: "StoreDB");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
