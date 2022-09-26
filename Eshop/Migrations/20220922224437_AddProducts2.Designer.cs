﻿// <auto-generated />
using Eshop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Eshop.Migrations
{
    [DbContext(typeof(EshopContext))]
    [Migration("20220922224437_AddProducts2")]
    partial class AddProducts2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Eshop.Models.Basket", b =>
                {
                    b.Property<int>("BasketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BasketID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BasketID");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("Eshop.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<int>("BasketID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            BasketID = 0,
                            Description = "Notebook",
                            Name = "EliteBook",
                            Price = 4,
                            Type = 3
                        },
                        new
                        {
                            ProductID = 2,
                            BasketID = 0,
                            Description = "Notebook",
                            Name = "EliteBook",
                            Price = 4,
                            Type = 3
                        },
                        new
                        {
                            ProductID = 3,
                            BasketID = 0,
                            Description = "Notebook",
                            Name = "EliteBook",
                            Price = 4,
                            Type = 3
                        },
                        new
                        {
                            ProductID = 4,
                            BasketID = 0,
                            Description = "Notebook",
                            Name = "EliteBook",
                            Price = 4,
                            Type = 3
                        },
                        new
                        {
                            ProductID = 5,
                            BasketID = 0,
                            Description = "Notebook",
                            Name = "EliteBook",
                            Price = 4,
                            Type = 3
                        },
                        new
                        {
                            ProductID = 6,
                            BasketID = 0,
                            Description = "Notebook",
                            Name = "EliteBook",
                            Price = 4,
                            Type = 3
                        },
                        new
                        {
                            ProductID = 7,
                            BasketID = 0,
                            Description = "Notebook",
                            Name = "EliteBook",
                            Price = 4,
                            Type = 3
                        },
                        new
                        {
                            ProductID = 8,
                            BasketID = 0,
                            Description = "Notebook",
                            Name = "EliteBook",
                            Price = 4,
                            Type = 3
                        },
                        new
                        {
                            ProductID = 9,
                            BasketID = 0,
                            Description = "Notebook",
                            Name = "EliteBook",
                            Price = 4,
                            Type = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
