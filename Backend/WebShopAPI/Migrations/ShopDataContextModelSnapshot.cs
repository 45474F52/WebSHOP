﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebShopAPI.Models.Data;

#nullable disable

namespace WebShopAPI.Migrations
{
    [DbContext(typeof(ShopDataContext))]
    partial class ShopDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebShopAPI.Models.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsUnicode(true)
                        .HasColumnType("tinytext");

                    b.Property<string>("Image")
                        .HasMaxLength(256)
                        .IsUnicode(true)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(256)
                        .IsUnicode(true)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("varchar(64)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 4)
                        .HasColumnType("decimal(10,4)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebShopAPI.Models.Data.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("WebShopAPI.Models.Data.Product", b =>
                {
                    b.HasOne("WebShopAPI.Models.Data.ProductCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebShopAPI.Models.Data.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
