namespace Catalog.API.Features.Courses.Update
{
    public static class UpdateCourseCommandEndpoint
    {
        public static RouteGroupBuilder UpdateCourseCommandEndpointExtension(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder.MapPut("/", async (UpdateCourseCommand updateCourseCommand, IMediator mediator) =>
            {
                var result = await mediator.Send(updateCourseCommand);
                return result.ToEndpointResult();
            }).WithName("UpdateCourse");

            return routeGroupBuilder;
        }
    }
}
