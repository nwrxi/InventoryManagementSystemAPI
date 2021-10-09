﻿// <auto-generated />
using System;
using InventoryManagementSystemAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventoryManagementSystemAPI.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210125084050_UniqueBarcode")]
    partial class UniqueBarcode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("InventoryManagementSystemAPI.Data.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Barcode")
                        .IsUnique();

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aa7673e2-41ad-46f5-b393-0e35fef773c9"),
                            Barcode = "3070006005009",
                            DateAdded = new DateTime(2021, 1, 25, 9, 40, 49, 740, DateTimeKind.Local).AddTicks(8190),
                            Name = "Item 1",
                            UserId = 0
                        },
                        new
                        {
                            Id = new Guid("85d2369f-c5c8-4432-aa54-f7b14742c899"),
                            Barcode = "0070006005002",
                            DateAdded = new DateTime(2021, 1, 25, 9, 40, 49, 746, DateTimeKind.Local).AddTicks(200),
                            Name = "Item 2",
                            UserId = 1
                        },
                        new
                        {
                            Id = new Guid("d81610ac-f03e-4d64-baa1-08366a9e0c9e"),
                            Barcode = "8074001005038",
                            DateAdded = new DateTime(2021, 1, 25, 9, 40, 49, 746, DateTimeKind.Local).AddTicks(256),
                            Name = "Item 3",
                            UserId = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}