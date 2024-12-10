namespace Basket.API.Features.Basket.ApplyDiscountCoupon
{
    public static class ApplyDiscountCouponEndpoint
    {
        public static RouteGroupBuilder ApplyDiscountCouponEndpointExtension(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder.MapPut("/apply-discount-coupon", async (ApplyDiscountCouponCommand applyDiscountCouponCommand, IMediator mediator) =>
            {
                var result = await mediator.Send(applyDiscountCouponCommand);
                return result.ToEndpointResult();
            }).WithName("ApplyDiscountCoupon");

            return routeGroupBuilder;
        }
    }
}
