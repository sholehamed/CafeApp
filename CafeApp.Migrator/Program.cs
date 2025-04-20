using CafeApp.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CafeApp.Migrator
{
    internal class Program
    {
        public class BloggingContextFactory : IDesignTimeDbContextFactory<CafeDbContext>
        {
            public CafeDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<CafeDbContext>();
                optionsBuilder.UseSqlServer("Server=.;Database=CafeAppDb;Trusted_Connection=True;MultipleActiveResultSets=true;User Id=sa;Password=H@med24121373;TrustServerCertificate=True",b=>b.MigrationsAssembly("CafeApp.Migrator"));

                return new CafeDbContext(optionsBuilder.Options);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
