using Catalog.API.Features.Courses.Dtos;

namespace Catalog.API.Features.Courses.GetAllByUserId
{
    public record GetAllCourseByUserIdQuery(Guid UserId) : IRequest<ServiceResult<List<CourseDto>>>;
}
