﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLayer.Repository;

#nullable disable

namespace NLayer.Repository.Migrations
{
    [DbContext(typeof(AppdbContext))]
    partial class AppdbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NlayerCoreApp.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kalemler"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Silgiler"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Defterler"
                        });
                });

            modelBuilder.Entity("NlayerCoreApp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreateDate = new DateTime(2023, 9, 6, 21, 32, 58, 836, DateTimeKind.Local).AddTicks(5406),
                            Name = "Kalem A",
                            Price = 100m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreateDate = new DateTime(2023, 9, 6, 21, 32, 58, 836, DateTimeKind.Local).AddTicks(5416),
                            Name = "Kalem B",
                            Price = 100m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreateDate = new DateTime(2023, 9, 6, 21, 32, 58, 836, DateTimeKind.Local).AddTicks(5417),
                            Name = "Kalem C",
                            Price = 100m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            CreateDate = new DateTime(2023, 9, 6, 21, 32, 58, 836, DateTimeKind.Local).AddTicks(5418),
                            Name = "Kalem C",
                            Price = 100m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CreateDate = new DateTime(2023, 9, 6, 21, 32, 58, 836, DateTimeKind.Local).AddTicks(5419),
                            Name = "Silgi C",
                            Price = 100m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            CreateDate = new DateTime(2023, 9, 6, 21, 32, 58, 836, DateTimeKind.Local).AddTicks(5420),
                            Name = "Silgi C",
                            Price = 100m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            CreateDate = new DateTime(2023, 9, 6, 21, 32, 58, 836, DateTimeKind.Local).AddTicks(5421),
                            Name = "Silgi C",
                            Price = 100m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            CreateDate = new DateTime(2023, 9, 6, 21, 32, 58, 836, DateTimeKind.Local).AddTicks(5422),
                            Name = "Defter A",
                            Price = 100m,
                            Stock = 20
                        });
                });

            modelBuilder.Entity("NlayerCoreApp.Models.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductFeatures", (string)null);
                });

            modelBuilder.Entity("NlayerCoreApp.Models.Product", b =>
                {
                    b.HasOne("NlayerCoreApp.Models.Category", "Categorys")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorys");
                });

            modelBuilder.Entity("NlayerCoreApp.Models.ProductFeature", b =>
                {
                    b.HasOne("NlayerCoreApp.Models.Product", "Products")
                        .WithOne("ProductFeatures")
                        .HasForeignKey("NlayerCoreApp.Models.ProductFeature", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("NlayerCoreApp.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NlayerCoreApp.Models.Product", b =>
                {
                    b.Navigation("ProductFeatures");
                });
#pragma warning restore 612, 618
        }
    }
}