using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NgocNhanShop.EF.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NgocNhanShop.Data.EF
{
    public class NgocNhanShopContextFactory : IDesignTimeDbContextFactory<NgocNhanShopDbContext>
    {
        public NgocNhanShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsetting.json").Build();
            var configurationString = configuration.GetConnectionString("NgocNhanShopDatabase");
            var optionsBuilder = new DbContextOptionsBuilder<NgocNhanShopDbContext>();
            optionsBuilder.UseSqlServer(configurationString);

            return new NgocNhanShopDbContext(optionsBuilder.Options);
        }
    }
}
