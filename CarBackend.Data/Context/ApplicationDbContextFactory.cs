using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarBackend.Data.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Connection string for migrations
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CarCounterDB;Username=postgres;Password=reta2006..");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}