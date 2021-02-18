using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystemAPI.Data.Migrations
{
    public partial class BarcodeValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7dbc38dc-c7cf-4b3d-91a3-60913f00112a"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("f077bf7b-4f83-474e-ae6d-786ce3237663"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("fab75011-08c4-495b-b86f-913b217fa342"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("7dbc38dc-c7cf-4b3d-91a3-60913f00112a"), "0", new DateTime(2021, 1, 23, 14, 42, 11, 82, DateTimeKind.Local).AddTicks(2320), "Item 1", 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("fab75011-08c4-495b-b86f-913b217fa342"), "1", new DateTime(2021, 1, 23, 14, 42, 11, 86, DateTimeKind.Local).AddTicks(9706), "Item 2", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("f077bf7b-4f83-474e-ae6d-786ce3237663"), "2", new DateTime(2021, 1, 23, 14, 42, 11, 86, DateTimeKind.Local).AddTicks(9742), "Item 3", 2 });
        }
    }
}
