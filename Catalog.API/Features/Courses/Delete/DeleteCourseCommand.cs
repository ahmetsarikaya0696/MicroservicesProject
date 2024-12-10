namespace Catalog.API.Features.Courses.Delete
{
    public record DeleteCourseCommand(Guid Id) : IRequest<ServiceResult>;
}
