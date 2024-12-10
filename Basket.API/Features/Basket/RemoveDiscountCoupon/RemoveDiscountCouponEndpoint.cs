namespace Basket.API.Features.Basket.RemoveDiscountCoupon
{
    public static class RemoveDiscountCouponEndpoint
    {
        public static RouteGroupBuilder RemoveDiscountCouponEndpointExtension(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder.MapDelete("/remove-discount-coupon", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new RemoveDiscountCouponCommand());
                return result.ToEndpointResult();
            }).WithName("RemoveDiscountCoupon");

            return routeGroupBuilder;
        }
    }
}
