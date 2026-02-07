using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public class ETicaretAPIDbContextFactory : IDesignTimeDbContextFactory<ETicaretAPIDbContext>
    {
        public ETicaretAPIDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ETicaretAPIDbContext>();

            optionsBuilder.UseNpgsql(
                "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=ETicaretAPIDb;");

            return new ETicaretAPIDbContext(optionsBuilder.Options);
        }
    }
}
