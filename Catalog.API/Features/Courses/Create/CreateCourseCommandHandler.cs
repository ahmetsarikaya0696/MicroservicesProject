
namespace Catalog.API.Features.Courses.Create
{
    public class CreateCourseCommandHandler(AppDbContext appDbContext, IMapper mapper) : IRequestHandler<CreateCourseCommand, ServiceResult<Guid>>
    {
        public async Task<ServiceResult<Guid>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            bool categoryExist = await appDbContext.Categories.AnyAsync(x => x.Id == request.CategoryId, cancellationToken);
            if (!categoryExist)
                return ServiceResult<Guid>.Error("Category not found", $"The category with the Id({request.CategoryId}) was not found", HttpStatusCode.NotFound);

            bool sameCourseNameExist = await appDbContext.Courses.AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (sameCourseNameExist)
                return ServiceResult<Guid>.Error("Course name already exists", $"Course with the given name '{request.Name}' already exists", HttpStatusCode.BadRequest);

            var newCourse = mapper.Map<Course>(request);
            newCourse.Id = NewId.NextSequentialGuid();
            newCourse.CreatedDate = DateTime.UtcNow;
            newCourse.Feature = new Feature() { Duration = 10, EducatorFullName = "Ahmet Sarıkaya", Rating = 4.8f };

            await appDbContext.Courses.AddAsync(newCourse, cancellationToken);
            await appDbContext.SaveChangesAsync();

            return ServiceResult<Guid>.SuccessAsCreated(newCourse.Id, $"/api/courses/{newCourse.Id}");
        }
    }
}
