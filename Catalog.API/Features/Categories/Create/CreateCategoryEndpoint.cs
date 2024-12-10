namespace Catalog.API.Features.Categories.Create
{
    public static class CreateCategoryEndpoint
    {
        public static RouteGroupBuilder CreateCategoryEndpointExtension(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder.MapPost("/", async (CreateCategoryCommand createCategoryCommand, IMediator mediator) =>
            {
                var result = await mediator.Send(createCategoryCommand);
                return result.ToEndpointResult();
            }).WithName("CreateCategory")
              .MapToApiVersion(1, 0);

            return routeGroupBuilder;
        }
    }
}
