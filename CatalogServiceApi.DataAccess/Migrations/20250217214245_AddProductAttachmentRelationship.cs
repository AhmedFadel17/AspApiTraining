using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogServiceApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductAttachmentRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductAttachments_ProductId",
                table: "ProductAttachments",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttachments_Products_ProductId",
                table: "ProductAttachments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttachments_Products_ProductId",
                table: "ProductAttachments");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttachments_ProductId",
                table: "ProductAttachments");
        }
    }
}
