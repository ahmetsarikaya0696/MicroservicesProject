using Catalog.API.Features.Courses.Dtos;

namespace Catalog.API.Features.Courses.GetAllByUserId
{
    public class GetAllCourseByUserIdQueryHandler(AppDbContext appDbContext, IMapper mapper) : IRequestHandler<GetAllCourseByUserIdQuery, ServiceResult<List<CourseDto>>>
    {
        public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCourseByUserIdQuery request, CancellationToken cancellationToken)
        {
            var courses = await appDbContext.Courses.Where(x => x.UserId == request.UserId).ToListAsync(cancellationToken);

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
