using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystemAPI.Persistence.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("5fca3371-6f9f-4a0d-99a4-83df3fa34d66"), "0", new DateTime(2021, 1, 23, 11, 41, 20, 148, DateTimeKind.Local).AddTicks(3554), "Item 1", 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("5ffff381-a8e1-4faf-b059-79eb0a64ddc0"), "1", new DateTime(2021, 1, 23, 11, 41, 20, 152, DateTimeKind.Local).AddTicks(8530), "Item 2", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("a1fee671-6e34-4d2e-9f2e-d4eb0256cf39"), "2", new DateTime(2021, 1, 23, 11, 41, 20, 152, DateTimeKind.Local).AddTicks(8565), "Item 3", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5fca3371-6f9f-4a0d-99a4-83df3fa34d66"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5ffff381-a8e1-4faf-b059-79eb0a64ddc0"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a1fee671-6e34-4d2e-9f2e-d4eb0256cf39"));
        }
    }
}
