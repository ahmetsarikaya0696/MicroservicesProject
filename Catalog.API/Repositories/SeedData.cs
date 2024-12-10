using Catalog.API.Features.Categories;
using Catalog.API.Features.Courses;

namespace Catalog.API.Repositories
{
    public static class SeedData
    {
        public static async Task AddSeedDataAsyncExtension(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            appDbContext.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;

            if (!appDbContext.Categories.Any())
            {
                var categories = new List<Category>()
                {
                    new Category() {Id = NewId.NextSequentialGuid(), Name= "Development"},
                    new Category() {Id = NewId.NextSequentialGuid(), Name= "Business"},
                    new Category() {Id = NewId.NextSequentialGuid(), Name= "IT & Software"},
                    new Category() {Id = NewId.NextSequentialGuid(), Name= "Office Productivity"},
                    new Category() {Id = NewId.NextSequentialGuid(), Name= "Personal Development"}
                };

                await appDbContext.Categories.AddRangeAsync(categories);
                await appDbContext.SaveChangesAsync();
            }

            if (!appDbContext.Courses.Any())
            {
                var category = await appDbContext.Categories.FirstAsync();

                var courses = new List<Course>()
                {
                    new Course()
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name= "C#",
                        Description = "C# Course",
                        Price = 200,
                        UserId = NewId.NextSequentialGuid(),
                        CreatedDate = DateTime.UtcNow,
                        CategoryId = category.Id,
                        Feature = new Feature() { Duration = 10, Rating = 4.2f, EducatorFullName = "Ahmet Sarıkaya"}
                    },
                    new Course()
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name= "Javascript",
                        Description = "Javascript Course",
                        Price = 100,
                        UserId = NewId.NextSequentialGuid(),
                        CreatedDate = DateTime.UtcNow,
                        CategoryId = category.Id,
                        Feature = new Feature() { Duration = 8, Rating = 3.8f, EducatorFullName = "Ahmet Sarıkaya"}
                    },
                     new Course()
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name= "Python",
                        Description = "Python Course",
                        Price = 50,
                        UserId = NewId.NextSequentialGuid(),
                        CreatedDate = DateTime.UtcNow,
                        CategoryId = category.Id,
                        Feature = new Feature() { Duration = 15, Rating = 4.8f, EducatorFullName = "Ahmet Sarıkaya"}
                    },
                };

                await appDbContext.Courses.AddRangeAsync(courses);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
