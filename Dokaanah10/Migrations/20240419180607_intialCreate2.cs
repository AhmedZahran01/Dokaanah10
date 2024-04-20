using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dokaanah10.Migrations
{
    /// <inheritdoc />
    public partial class intialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Products_Carts_CartId",
                table: "Cart_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Products_Products_ProductId",
                table: "Cart_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_Categories_CategoryId",
                table: "Product_Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_Products_ProductId",
                table: "Product_Categories");

            migrationBuilder.DropIndex(
                name: "IX_Product_Categories_CategoryId",
                table: "Product_Categories");

            migrationBuilder.DropIndex(
                name: "IX_Product_Categories_ProductId",
                table: "Product_Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart_Products",
                table: "Cart_Products");

            migrationBuilder.DropIndex(
                name: "IX_Cart_Products_CartId",
                table: "Cart_Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Product_Categories");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Product_Categories");

            migrationBuilder.DropColumn(
                name: "Cid",
                table: "Cart_Products");

            migrationBuilder.DropColumn(
                name: "Pid",
                table: "Cart_Products");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Cart_Products",
                newName: "Caid");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Cart_Products",
                newName: "Prid");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_Products_ProductId",
                table: "Cart_Products",
                newName: "IX_Cart_Products_Caid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart_Products",
                table: "Cart_Products",
                columns: new[] { "Prid", "Caid" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Categories_Cid",
                table: "Product_Categories",
                column: "Cid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Products_Carts_Caid",
                table: "Cart_Products",
                column: "Caid",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Products_Products_Prid",
                table: "Cart_Products",
                column: "Prid",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_Categories_Cid",
                table: "Product_Categories",
                column: "Cid",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_Products_Pid",
                table: "Product_Categories",
                column: "Pid",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Products_Carts_Caid",
                table: "Cart_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Products_Products_Prid",
                table: "Cart_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_Categories_Cid",
                table: "Product_Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_Products_Pid",
                table: "Product_Categories");

            migrationBuilder.DropIndex(
                name: "IX_Product_Categories_Cid",
                table: "Product_Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart_Products",
                table: "Cart_Products");

            migrationBuilder.RenameColumn(
                name: "Caid",
                table: "Cart_Products",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Prid",
                table: "Cart_Products",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_Products_Caid",
                table: "Cart_Products",
                newName: "IX_Cart_Products_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Product_Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Product_Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cid",
                table: "Cart_Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pid",
                table: "Cart_Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart_Products",
                table: "Cart_Products",
                columns: new[] { "Cid", "Pid" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Categories_CategoryId",
                table: "Product_Categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Categories_ProductId",
                table: "Product_Categories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Products_CartId",
                table: "Cart_Products",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Products_Carts_CartId",
                table: "Cart_Products",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Products_Products_ProductId",
                table: "Cart_Products",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_Categories_CategoryId",
                table: "Product_Categories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_Products_ProductId",
                table: "Product_Categories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
