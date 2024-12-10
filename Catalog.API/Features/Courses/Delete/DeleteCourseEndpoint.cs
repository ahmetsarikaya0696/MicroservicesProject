namespace Catalog.API.Features.Courses.Delete
{
    public static class DeleteCourseEndpoint
    {
        public static RouteGroupBuilder DeleteCourseEndpointExtension(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder.MapDelete("/{id:guid}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new DeleteCourseCommand(id));
                return result.ToEndpointResult();
            }).WithName("DeleteCourse");

            return routeGroupBuilder;
        }
    }
}
