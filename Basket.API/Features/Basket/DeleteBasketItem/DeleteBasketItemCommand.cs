namespace Basket.API.Features.Basket.DeleteBasketItem
{
    public record DeleteBasketItemCommand(Guid BasketItemId) : IRequest<ServiceResult>;
}
