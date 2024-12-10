
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.Courses.Create
{
    public static class CreateCourseEndpoint
    {
        public static RouteGroupBuilder CreateCourseEndpointExtension(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder.MapPost("/", async (CreateCourseCommand createCourseCommand, IMediator mediator) =>
            {
                var result = await mediator.Send(createCourseCommand);
                return result.ToEndpointResult();
            }).WithName("CreateCourse")
              .Produces<Guid>(StatusCodes.Status201Created)
              .Produces(StatusCodes.Status404NotFound)
              .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
              .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return routeGroupBuilder;
        }
    }
}
