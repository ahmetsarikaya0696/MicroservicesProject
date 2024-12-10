using System.Net;
using System.Text.Json;

namespace Basket.API.Features.Basket.RemoveDiscountCoupon
{
    public class RemoveDiscountCouponCommandHandler(IBasketService basketService) : IRequestHandler<RemoveDiscountCouponCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(RemoveDiscountCouponCommand request, CancellationToken cancellationToken)
        {
            var basketAsJson = await basketService.GetBasketJsonFromCacheAsync(cancellationToken);

            if (string.IsNullOrEmpty(basketAsJson)) return ServiceResult.Error("Basket not found", HttpStatusCode.NotFound);

            var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsJson);
            basket!.ClearDiscount();

            basketAsJson = JsonSerializer.Serialize(basket);

            await basketService.CreateBasketCacheAsync(basketAsJson, cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
