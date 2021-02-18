using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystemAPI.Data.Migrations
{
    public partial class FixNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("01529d5b-0164-4557-b20e-06adb9b7e47f"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("87322a2b-cc22-49bd-8401-7f61c552ad73"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a06170fc-cd9d-425e-a993-764adb2db441"));

            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "AspNetUsers",
                newName: "LastName");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "SecondName");

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("01529d5b-0164-4557-b20e-06adb9b7e47f"), "3070006005009", new DateTime(2021, 2, 6, 11, 18, 47, 941, DateTimeKind.Local).AddTicks(9959), "Item 1", 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("a06170fc-cd9d-425e-a993-764adb2db441"), "0070006005002", new DateTime(2021, 2, 6, 11, 18, 47, 944, DateTimeKind.Local).AddTicks(5883), "Item 2", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Barcode", "DateAdded", "Name", "UserId" },
                values: new object[] { new Guid("87322a2b-cc22-49bd-8401-7f61c552ad73"), "8074001005038", new DateTime(2021, 2, 6, 11, 18, 47, 944, DateTimeKind.Local).AddTicks(5906), "Item 3", 2 });
        }
    }
}
