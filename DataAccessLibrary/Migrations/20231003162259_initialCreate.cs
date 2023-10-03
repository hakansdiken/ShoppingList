using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ShopLists",
                columns: table => new
                {
                    ShopListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopListName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopLists", x => x.ShopListId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductShopList",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ShopListId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShopList", x => new { x.ProductId, x.ShopListId });
                    table.ForeignKey(
                        name: "FK_ProductShopList_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductShopList_ShopLists_ShopListId",
                        column: x => x.ShopListId,
                        principalTable: "ShopLists",
                        principalColumn: "ShopListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Teknoloji" },
                    { 2, "Ev Gereçleri" },
                    { 3, "Mutfak" }
                });

            migrationBuilder.InsertData(
                table: "ShopLists",
                columns: new[] { "ShopListId", "ShopListName", "State" },
                values: new object[,]
                {
                    { 1, "Mutfak Listem", true },
                    { 2, "Teknoloji Listem", true },
                    { 3, "Ev Listem", true }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductImage", "ProductName" },
                values: new object[,]
                {
                    { 1, 1, "cable.png", "Şarj Kablosu" },
                    { 2, 2, "wipes.png", "Islak Mendil" },
                    { 3, 3, "water.png", "Su" },
                    { 4, 3, "sugar.png", "Şeker" },
                    { 5, 1, "keyboard.png", "Klavye" }
                });

            migrationBuilder.InsertData(
                table: "ProductShopList",
                columns: new[] { "ProductId", "ShopListId", "Note" },
                values: new object[,]
                {
                    { 1, 2, "2 tane şarj kablosu" },
                    { 2, 3, null },
                    { 3, 1, null },
                    { 4, 1, null },
                    { 5, 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShopList_ShopListId",
                table: "ProductShopList",
                column: "ShopListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductShopList");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShopLists");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
