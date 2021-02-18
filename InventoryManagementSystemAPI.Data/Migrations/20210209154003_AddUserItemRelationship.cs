using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystemAPI.Data.Migrations
{
    public partial class AddUserItemRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("46ab9fa1-d75f-49dc-9cbd-a870c95d3240"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5d4cd258-d9a6-48a3-bdb2-af2257919d5f"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a11fe921-dee1-4b35-a877-ca848bf1ecdb"));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Items",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserId",
                table: "Items",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_UserId",
                table: "Items",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_UserId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_UserId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("a11fe921-dee1-4b35-a877-ca848bf1ecdb"), "3070006005009", new DateTime(2021, 2, 6, 13, 21, 54, 834, DateTimeKind.Local).AddTicks(1466), "Item 1", 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("46ab9fa1-d75f-49dc-9cbd-a870c95d3240"), "0070006005002", new DateTime(2021, 2, 6, 13, 21, 54, 836, DateTimeKind.Local).AddTicks(7031), "Item 2", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("5d4cd258-d9a6-48a3-bdb2-af2257919d5f"), "8074001005038", new DateTime(2021, 2, 6, 13, 21, 54, 836, DateTimeKind.Local).AddTicks(7054), "Item 3", 2 });
        }
    }
}
