namespace Catalog.API.Features.Courses.GetById
{
    public static class GetCourseByIdEndpoint
    {
        public static RouteGroupBuilder GetCourseByIdEndpointExtension(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetCourseByIdQuery(id));
                return result.ToEndpointResult();
            }).WithName("GetCourseById");

            return routeGroupBuilder;
        }
    }
}
