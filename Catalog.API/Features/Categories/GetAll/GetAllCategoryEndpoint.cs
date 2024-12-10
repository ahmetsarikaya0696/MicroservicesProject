namespace Catalog.API.Features.Categories.GetAll
{
    public static class GetAllCategoryEndpoint
    {
        public static RouteGroupBuilder GetAllCategoryEndpointExtension(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAllCategoryQuery());
                return result.ToEndpointResult();
            }).WithName("GetAllCategory")
              .MapToApiVersion(1, 0);

            return routeGroupBuilder;
        }
    }
}
