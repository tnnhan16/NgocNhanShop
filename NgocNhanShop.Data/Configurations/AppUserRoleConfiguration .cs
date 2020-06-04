using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgocNhanShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Data.Configurations
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppRoleAction>
    {
        public void Configure(EntityTypeBuilder<AppRoleAction> builder)
        {
            builder.ToTable("AppRoleAction");

            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(sc => new { sc.RoleId, sc.ActionId });

            builder.HasOne<AppRole>(sc => sc.AppRoles)
                .WithMany(s => s.AppRoleActions)
                .HasForeignKey(sc => sc.RoleId);


            builder.HasOne<AppAction>(sc => sc.AppActions)
            .WithMany(s => s.AppRoleActions)
            .HasForeignKey(sc => sc.ActionId);
        }



}

}
