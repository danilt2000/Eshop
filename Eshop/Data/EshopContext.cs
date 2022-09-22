using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Eshop.Models;

namespace Eshop.Data
{
    public class EshopContext : DbContext
    {
        public EshopContext (DbContextOptions<EshopContext> options)
            : base(options)
        {
        }

        public DbSet<Eshop.Models.Product> Product { get; set; } = default!;
        public DbSet<Eshop.Models.Basket> Basket { get; set; } = default!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                    new Product { ProductID = 1, Name = "EliteBook", Description = "Notebook" ,Price =4 , Type=ProductType.Computers }
            );
        }


    }
}
