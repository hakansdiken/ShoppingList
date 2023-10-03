using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    internal class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopList> ShopLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.; Database=ShopListDB; Trusted_Connection=True; Encrypt=True; TrustServerCertificate=Yes;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductShopList>()
                .HasKey(ps => new { ps.ProductId, ps.ShopListId });

            modelBuilder.Entity<ProductShopList>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ShopLists)
                .HasForeignKey(ps => ps.ProductId);

            modelBuilder.Entity<ProductShopList>()
                .HasOne(ps => ps.ShopList)
                .WithMany(s => s.Products)
                .HasForeignKey(ps => ps.ShopListId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);


            //DATA SEED
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category() { CategoryId = 1, CategoryName = "Teknoloji" },
                    new Category() { CategoryId = 2, CategoryName = "Ev Gereçleri" },
                    new Category() { CategoryId = 3, CategoryName = "Mutfak" }
                );
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product() { ProductId = 1, CategoryId = 1, ProductName = "Şarj Kablosu", ProductImage = "cable.png" },
                    new Product() { ProductId = 2, CategoryId = 2, ProductName = "Islak Mendil", ProductImage = "wipes.png" },
                    new Product() { ProductId = 3, CategoryId = 3, ProductName = "Su", ProductImage = "water.png" },
                    new Product() { ProductId = 4, CategoryId = 3, ProductName = "Şeker", ProductImage = "sugar.png" },
                    new Product() { ProductId = 5, CategoryId = 1, ProductName = "Klavye", ProductImage = "keyboard.png" }
                );
            modelBuilder.Entity<ShopList>()
                .HasData(
                    new ShopList() { ShopListId = 1, ShopListName = "Mutfak Listem" },
                    new ShopList() { ShopListId = 2, ShopListName = "Teknoloji Listem" },
                    new ShopList() { ShopListId = 3, ShopListName = "Ev Listem"}
                );
            modelBuilder.Entity<ProductShopList>()
                .HasData(
                    new ProductShopList() { ProductId = 1, ShopListId = 2, Note = "2 tane şarj kablosu" },
                    new ProductShopList() { ProductId = 5, ShopListId = 2 },
                    new ProductShopList() { ProductId = 2, ShopListId = 3 },
                    new ProductShopList() { ProductId = 3, ShopListId = 1 },
                    new ProductShopList() { ProductId = 4, ShopListId = 1 }
                );

        }
    }
}