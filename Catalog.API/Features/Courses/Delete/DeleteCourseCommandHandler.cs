
namespace Catalog.API.Features.Courses.Delete
{
    public class DeleteCourseCommandHandler(AppDbContext appDbContext) : IRequestHandler<DeleteCourseCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await appDbContext.Courses.FindAsync(request.Id, cancellationToken);
            if (course is null) return ServiceResult.ErrorAsNotFound();

            appDbContext.Courses.Remove(course);
            await appDbContext.SaveChangesAsync();

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
