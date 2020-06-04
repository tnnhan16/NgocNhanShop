using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgocNhanShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Data.Configurations
{
    public class AppActionConfiguration : IEntityTypeConfiguration<AppAction>
    {
        public void Configure(EntityTypeBuilder<AppAction> builder)
        {
            builder.ToTable("AppActions");
            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);
            builder.HasKey(x => x.Id);
        }
    }
}
