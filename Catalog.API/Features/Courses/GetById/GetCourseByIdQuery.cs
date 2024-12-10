
using Catalog.API.Features.Courses.Dtos;

namespace Catalog.API.Features.Courses.GetById
{
    public record GetCourseByIdQuery(Guid Id) : IRequest<ServiceResult<CourseDto>>;
}