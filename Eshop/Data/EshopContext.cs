using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Eshop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Eshop.Data
{
    public class EshopContext : IdentityDbContext
    {
        public EshopContext(DbContextOptions<EshopContext> options)
            : base(options)
        {
        }
        //public EshopContext(DbContextOptions<EshopContext> options)
        //    : base(options)
        //{
        //}

        public DbSet<Eshop.Models.Product> Product { get; set; } = default!;
        public DbSet<Eshop.Models.Basket> Basket { get; set; } = default!;
        public DbSet<Eshop.Models.Basket> User { get; set; } = default!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            
            modelBuilder.Entity<Product>().HasData(
                    new Product { ProductID = 1, Name = "EliteBook", Description = "Notebook", Price = 4, Type = ProductType.Computers }
            ); modelBuilder.Entity<Product>().HasData(
                   new Product { ProductID = 2, Name = "Multicooker", Description = "Multicooker", Price = 4, Type = ProductType.HomeAppliances }
           ); modelBuilder.Entity<Product>().HasData(
                  new Product { ProductID = 3, Name = "Mouse", Description = "Mouse", Price = 4, Type = ProductType.Computers }
          ); modelBuilder.Entity<Product>().HasData(
                 new Product { ProductID = 4, Name = "Wire", Description = "Notebook", Price = 4, Type = ProductType.Computers }
         ); modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 5, Name = "AutoWire", Description = "AutoWire", Price = 4, Type = ProductType.AutoStuff }
        );
            modelBuilder.Entity<Basket>().HasData(
                    new Basket { BasketID = 1, Name = "StartBasket" }
            );


            base.OnModelCreating(modelBuilder);

        }


    }
}
