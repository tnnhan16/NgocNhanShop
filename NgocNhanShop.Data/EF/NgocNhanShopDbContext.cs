using Microsoft.EntityFrameworkCore;
using NgocNhanShop.Data.Configurations;
using NgocNhanShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NgocNhanShop.EF.Data
{
    public class NgocNhanShopDbContext : DbContext
    {
        public NgocNhanShopDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
