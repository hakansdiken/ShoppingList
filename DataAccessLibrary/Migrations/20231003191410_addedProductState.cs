using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedProductState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBought",
                table: "ProductShopList",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ProductShopList",
                keyColumns: new[] { "ProductId", "ShopListId" },
                keyValues: new object[] { 1, 2 },
                column: "IsBought",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductShopList",
                keyColumns: new[] { "ProductId", "ShopListId" },
                keyValues: new object[] { 2, 3 },
                column: "IsBought",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductShopList",
                keyColumns: new[] { "ProductId", "ShopListId" },
                keyValues: new object[] { 3, 1 },
                column: "IsBought",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductShopList",
                keyColumns: new[] { "ProductId", "ShopListId" },
                keyValues: new object[] { 4, 1 },
                column: "IsBought",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductShopList",
                keyColumns: new[] { "ProductId", "ShopListId" },
                keyValues: new object[] { 5, 2 },
                column: "IsBought",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBought",
                table: "ProductShopList");
        }
    }
}
