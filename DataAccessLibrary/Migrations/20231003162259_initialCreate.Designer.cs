﻿// <auto-generated />
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231003162259_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Teknoloji"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Ev Gereçleri"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Mutfak"
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            ProductImage = "cable.png",
                            ProductName = "Şarj Kablosu"
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2,
                            ProductImage = "wipes.png",
                            ProductName = "Islak Mendil"
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3,
                            ProductImage = "water.png",
                            ProductName = "Su"
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 3,
                            ProductImage = "sugar.png",
                            ProductName = "Şeker"
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 1,
                            ProductImage = "keyboard.png",
                            ProductName = "Klavye"
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.ProductShopList", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ShopListId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId", "ShopListId");

                    b.HasIndex("ShopListId");

                    b.ToTable("ProductShopList");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ShopListId = 2,
                            Note = "2 tane şarj kablosu"
                        },
                        new
                        {
                            ProductId = 5,
                            ShopListId = 2
                        },
                        new
                        {
                            ProductId = 2,
                            ShopListId = 3
                        },
                        new
                        {
                            ProductId = 3,
                            ShopListId = 1
                        },
                        new
                        {
                            ProductId = 4,
                            ShopListId = 1
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.ShopList", b =>
                {
                    b.Property<int>("ShopListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShopListId"));

                    b.Property<string>("ShopListName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("ShopListId");

                    b.ToTable("ShopLists");

                    b.HasData(
                        new
                        {
                            ShopListId = 1,
                            ShopListName = "Mutfak Listem",
                            State = true
                        },
                        new
                        {
                            ShopListId = 2,
                            ShopListName = "Teknoloji Listem",
                            State = true
                        },
                        new
                        {
                            ShopListId = 3,
                            ShopListName = "Ev Listem",
                            State = true
                        });
                });

            modelBuilder.Entity("EntityLayer.Entities.Product", b =>
                {
                    b.HasOne("EntityLayer.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EntityLayer.Entities.ProductShopList", b =>
                {
                    b.HasOne("EntityLayer.Entities.Product", "Product")
                        .WithMany("ShopLists")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Entities.ShopList", "ShopList")
                        .WithMany("Products")
                        .HasForeignKey("ShopListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShopList");
                });

            modelBuilder.Entity("EntityLayer.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EntityLayer.Entities.Product", b =>
                {
                    b.Navigation("ShopLists");
                });

            modelBuilder.Entity("EntityLayer.Entities.ShopList", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
