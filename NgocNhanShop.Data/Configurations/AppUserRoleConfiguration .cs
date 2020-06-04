using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgocNhanShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.Data.Configurations
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.ToTable("AppUserRoles");
            builder.HasKey(sc => new { sc.UserId, sc.RoleId });
            builder.HasOne<AppRole>(sc => sc.AppRoles)
                .WithMany(s => s.AppUserRoles)
                .HasForeignKey(sc => sc.RoleId);
            builder.HasOne<AppUser>(sc => sc.AppUsers)
            .WithMany(s => s.AppUserRoles)
            .HasForeignKey(sc => sc.UserId);
        }



}

}
