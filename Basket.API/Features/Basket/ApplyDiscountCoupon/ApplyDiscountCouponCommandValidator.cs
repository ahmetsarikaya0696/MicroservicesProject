namespace Basket.API.Features.Basket.ApplyDiscountCoupon
{
    public class ApplyDiscountCouponCommandValidator : AbstractValidator<ApplyDiscountCouponCommand>
    {
        public ApplyDiscountCouponCommandValidator()
        {
            RuleFor(x => x.Coupon).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.DiscountRate).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0")
                                        .LessThanOrEqualTo(1).WithMessage("{PropertyName} must be less than or equal to 1");
        }
    }
}
