using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystemAPI.Data.Migrations
{
    public partial class UniqueBarcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("1b8bfde2-7110-4814-9366-6e8c1ed49236"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("8d3afcfd-39dd-4c9d-abfa-1d072cc63700"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ec99dfa9-8f7b-409c-a98e-4d316462b347"));

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("aa7673e2-41ad-46f5-b393-0e35fef773c9"), "3070006005009", new DateTime(2021, 1, 25, 9, 40, 49, 740, DateTimeKind.Local).AddTicks(8190), "Item 1", 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("85d2369f-c5c8-4432-aa54-f7b14742c899"), "0070006005002", new DateTime(2021, 1, 25, 9, 40, 49, 746, DateTimeKind.Local).AddTicks(200), "Item 2", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("d81610ac-f03e-4d64-baa1-08366a9e0c9e"), "8074001005038", new DateTime(2021, 1, 25, 9, 40, 49, 746, DateTimeKind.Local).AddTicks(256), "Item 3", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Items_Barcode",
                table: "Items",
                column: "Barcode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Items_Barcode",
                table: "Items");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("85d2369f-c5c8-4432-aa54-f7b14742c899"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("aa7673e2-41ad-46f5-b393-0e35fef773c9"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d81610ac-f03e-4d64-baa1-08366a9e0c9e"));

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("1b8bfde2-7110-4814-9366-6e8c1ed49236"), "0", new DateTime(2021, 1, 25, 8, 57, 47, 842, DateTimeKind.Local).AddTicks(2853), "Item 1", 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("ec99dfa9-8f7b-409c-a98e-4d316462b347"), "1", new DateTime(2021, 1, 25, 8, 57, 47, 847, DateTimeKind.Local).AddTicks(1405), "Item 2", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("8d3afcfd-39dd-4c9d-abfa-1d072cc63700"), "2", new DateTime(2021, 1, 25, 8, 57, 47, 847, DateTimeKind.Local).AddTicks(1465), "Item 3", 2 });
        }
    }
}
