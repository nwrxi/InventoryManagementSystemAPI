﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSystemAPI.Data.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Barcode = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
