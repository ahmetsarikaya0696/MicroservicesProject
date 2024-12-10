using System.Net;
using System.Text.Json;

namespace Basket.API.Features.Basket.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler(IBasketService basketService) : IRequestHandler<DeleteBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basketAsJson = await basketService.GetBasketJsonFromCacheAsync(cancellationToken);
            if (string.IsNullOrEmpty(basketAsJson)) return ServiceResult.Error("Basket not found", HttpStatusCode.NotFound);

            var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsJson);
            var basketItem = basket!.BasketItems.FirstOrDefault(x => x.Id == request.BasketItemId);
            if (basketItem is null) return ServiceResult.Error($"Basket does not contain basket item with the Id({request.BasketItemId})", HttpStatusCode.NotFound);

            basket.BasketItems.Remove(basketItem);
            var newBasketAsJson = JsonSerializer.Serialize(basket);

            await basketService.CreateBasketCacheAsync(newBasketAsJson, cancellationToken);
            return ServiceResult.SuccessAsNoContent();
        }
    }
}
