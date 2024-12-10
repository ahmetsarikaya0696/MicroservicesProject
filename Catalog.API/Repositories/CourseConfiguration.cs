using Catalog.API.Features.Courses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Catalog.API.Repositories
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToCollection("courses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(100).HasElementName("name");
            builder.Property(x => x.Description).HasElementName("description").HasMaxLength(1000);
            builder.Property(x => x.CreatedDate).HasElementName("createdDate");
            builder.Property(x => x.UserId).HasElementName("userId");
            builder.Property(x => x.CategoryId).HasElementName("categoryId");
            builder.Property(x => x.ImageUrl).HasElementName("imageUrl").HasMaxLength(200);
            builder.Ignore(x => x.Category);
            builder.OwnsOne(x => x.Feature, feature =>
            {
                feature.HasElementName("feature");
                feature.Property(x => x.Duration).HasElementName("duration");
                feature.Property(x => x.Rating).HasElementName("rating");
                feature.Property(x => x.EducatorFullName).HasElementName("educatorFullName");
            });
        }
    }
}