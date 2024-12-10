namespace Catalog.API.Features.Courses.GetAllByUserId
{
    public static class GetAllCourseByUserIdEndpoint
    {
        public static RouteGroupBuilder GetAllCourseByUserIdEndpointExtension(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder.MapGet("/user/{userId:guid}", async (Guid userId, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAllCourseByUserIdQuery(userId));
                return result.ToEndpointResult();
            }).WithName("GetAllCourseByUserId");

            return routeGroupBuilder;
        }
    }
}
