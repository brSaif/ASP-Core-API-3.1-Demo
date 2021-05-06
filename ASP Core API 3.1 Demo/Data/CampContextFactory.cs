using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ASP_Core_API_3._1_Demo.Data
{
    public class CampContextFactory : IDesignTimeDbContextFactory<CampContext>, IDbCampContextFactory
    {
        public CampContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return new CampContext(new DbContextOptionsBuilder<CampContext>().Options, config);
        }
    }
}
