using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgocNhanShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Price).IsRequired();
            builder.HasOne(c=>c.Category).WithMany(p => p.Products).HasForeignKey(p=>p.CategoryId);
        }
    }
}
