namespace Basket.API.Features.Basket.ApplyDiscountCoupon
{
    public record ApplyDiscountCouponCommand(string Coupon, float DiscountRate) : IRequest<ServiceResult>;
}
