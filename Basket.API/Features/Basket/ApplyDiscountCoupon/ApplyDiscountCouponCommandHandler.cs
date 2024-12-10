using Shared.Services;
using System.Net;
using System.Text.Json;

namespace Basket.API.Features.Basket.ApplyDiscountCoupon
{
    public class ApplyDiscountCouponCommandHandler(IIdentityService identityService, IBasketService basketService) : IRequestHandler<ApplyDiscountCouponCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(ApplyDiscountCouponCommand request, CancellationToken cancellationToken)
        {

            var basketAsJson = await basketService.GetBasketJsonFromCacheAsync(cancellationToken);

            if (string.IsNullOrEmpty(basketAsJson)) return ServiceResult.Error("Basket not found", HttpStatusCode.NotFound);

            var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsJson);

            if (!basket!.BasketItems.Any()) return ServiceResult.Error("Basket does not contain any basket item", HttpStatusCode.NotFound);

            basket!.ApplyNewDiscount(request.Coupon, request.DiscountRate);

            basketAsJson = JsonSerializer.Serialize(basket);

            await basketService.CreateBasketCacheAsync(basket, cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
