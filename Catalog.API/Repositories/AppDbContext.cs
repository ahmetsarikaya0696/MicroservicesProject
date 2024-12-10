using Catalog.API.Features.Categories;
using Catalog.API.Features.Courses;
using MongoDB.Driver;
using System.Reflection;

namespace Catalog.API.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public static AppDbContext Create(IMongoDatabase mongoDatabase)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseMongoDB(mongoDatabase.Client, mongoDatabase.DatabaseNamespace.DatabaseName);
            var appDbContext = new AppDbContext(optionsBuilder.Options);
            return appDbContext;
        }


        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
