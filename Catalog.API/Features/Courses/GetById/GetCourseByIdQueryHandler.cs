using Catalog.API.Features.Courses.Dtos;

namespace Catalog.API.Features.Courses.GetById
{
    public class GetCourseByIdQueryHandler(AppDbContext appDbContext, IMapper mapper) : IRequestHandler<GetCourseByIdQuery, ServiceResult<CourseDto>>
    {
        public async Task<ServiceResult<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await appDbContext.Courses.FindAsync(request.Id, cancellationToken);

            if (course is null)
                return ServiceResult<CourseDto>.Error("Course not found", $"Course with the Id({request.Id}) was not found", HttpStatusCode.NotFound);

            course.Category = await appDbContext.Categories.FirstAsync(x => x.Id == course.CategoryId, cancellationToken);

            var mappedCourse = mapper.Map<CourseDto>(course);

            return ServiceResult<CourseDto>.SuccessAsOk(mappedCourse);
        }
    }
}
