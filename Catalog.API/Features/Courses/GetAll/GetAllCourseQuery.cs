
using Catalog.API.Features.Courses.Dtos;

namespace Catalog.API.Features.Courses.GetAll
{
    public record GetAllCourseQuery : IRequest<ServiceResult<List<CourseDto>>>;
}