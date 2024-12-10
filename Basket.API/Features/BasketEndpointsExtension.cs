using Asp.Versioning.Builder;
using Basket.API.Features.Basket.AddBasketItem;
using Basket.API.Features.Basket.ApplyDiscountCoupon;
using Basket.API.Features.Basket.DeleteBasketItem;
using Basket.API.Features.Basket.GetBasket;
using Basket.API.Features.Basket.RemoveDiscountCoupon;
using Shared.Filters;

namespace Basket.API.Features
{
    public static class BasketEndpointsExtension
    {
        public static void AddBasketEndpointsExtension(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/baskets")
               .WithTags("Baskets")
               .WithApiVersionSet(apiVersionSet)
               .AddBasketItemEndpointExtension()
               .DeleteBasketItemEndpointExtension()
               .GetBasketEndpointExtension()
               .ApplyDiscountCouponEndpointExtension()
               .RemoveDiscountCouponEndpointExtension()
               .AddEndpointFilter<FluentValidationFilter>();
        }
    }
}
