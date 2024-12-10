namespace Basket.API.Features.Basket.GetBasket
{
    public static class GetBasketEndpoint
    {
        public static RouteGroupBuilder GetBasketEndpointExtension(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder.MapGet("/user", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetBasketQuery());
                return result.ToEndpointResult();
            }).WithName("GetBasket");

            return routeGroupBuilder;
        }
    }
}
