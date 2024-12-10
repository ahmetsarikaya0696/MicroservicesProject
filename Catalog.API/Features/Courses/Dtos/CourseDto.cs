namespace Catalog.API.Features.Courses.Dtos
{
    public record CourseDto(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        Guid UserId,
        string? ImageUrl,
        DateTime CreatedDate,
        CategoryDto Category,
        FeatureDto Feature);
}
