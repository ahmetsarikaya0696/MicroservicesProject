using Catalog.API.Features.Courses.Dtos;

namespace Catalog.API.Features.Courses.GetAll
{
    public class GetAllCourseQueryHandler(AppDbContext appDbContext, IMapper mapper) : IRequestHandler<GetAllCourseQuery, ServiceResult<List<CourseDto>>>
    {
        public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            var courses = await appDbContext.Courses.ToListAsync(cancellationToken);
            var categories = await appDbContext.Categories.ToListAsync(cancellationToken);

            courses.ForEach(course =>
            {
                course.Category = categories.First(x => x.Id == course.CategoryId);
            });

            var mappedCourses = mapper.Map<List<CourseDto>>(courses);

            return ServiceResult<List<CourseDto>>.SuccessAsOk(mappedCourses);
        }
    }
}
