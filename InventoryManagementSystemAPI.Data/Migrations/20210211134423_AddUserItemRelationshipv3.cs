using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystemAPI.Data.Migrations
{
    public partial class AddUserItemRelationshipv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Items_Barcode",
                table: "Items");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Items_Barcode",
                table: "Items",
                column: "Barcode",
                unique: true);
        }
    }
}
