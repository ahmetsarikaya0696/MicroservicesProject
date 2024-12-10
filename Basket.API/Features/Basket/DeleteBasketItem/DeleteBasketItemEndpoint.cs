namespace Basket.API.Features.Basket.DeleteBasketItem
{
    public static class DeleteBasketItemEndpoint
    {
        public static RouteGroupBuilder DeleteBasketItemEndpointExtension(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder.MapDelete("/item/{id:guid}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new DeleteBasketItemCommand(id));
                return result.ToEndpointResult();
            }).WithName("DeleteBasketItem");

            return routeGroupBuilder;
        }
    }
}
