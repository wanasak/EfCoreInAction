using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer.Codes
{
    public class ContextFactoryNeededForMigrations : IDesignTimeDbContextFactory<EfCoreContext>
    {
        private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=EfCoreInActionDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        public EfCoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EfCoreContext>();
            optionsBuilder.UseSqlServer(ConnectionString, b => b.MigrationsAssembly("DataLayer"));

            return new EfCoreContext(optionsBuilder.Options);
        }
    }
}
