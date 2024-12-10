namespace Catalog.API.Features.Courses.GetAll
{
    public static class GetAllCourseEndpoint
    {
        public static RouteGroupBuilder GetAllCourseEndpointExtension(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAllCourseQuery());
                return result.ToEndpointResult();
            }).WithName("GetAllCourse");

            return routeGroupBuilder;
        }
    }
}
