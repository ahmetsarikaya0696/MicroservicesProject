namespace Basket.API.Features.Basket.AddBasketItem
{
    public static class AddBasketItemEndpoint
    {
        public static RouteGroupBuilder AddBasketItemEndpointExtension(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder.MapPost("/item", async (AddBasketItemCommand addBasketItemCommand, IMediator mediator) =>
            {
                var result = await mediator.Send(addBasketItemCommand);
                return result.ToEndpointResult();
            }).WithName("AddBasketItem");

            return routeGroupBuilder;
        }
    }
}
