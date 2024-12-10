
namespace Catalog.API.Features.Courses.Update
{
    public class UpdateCourseCommandHandler(AppDbContext appDbContext, IMapper mapper) : IRequestHandler<UpdateCourseCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await appDbContext.Courses.FindAsync(request.Id, cancellationToken);

            if (course is null) return ServiceResult.ErrorAsNotFound();

            mapper.Map(request, course);

            appDbContext.Update(course);
            await appDbContext.SaveChangesAsync();

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
