namespace Basket.API.Features.Basket.AddBasketItem
{
    public class AddBasketItemValidator : AbstractValidator<AddBasketItemCommand>
    {
        public AddBasketItemValidator()
        {
            RuleFor(x => x.CourseId).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.CourseName).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.CoursePrice).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
            RuleFor(x => x.CourseImageUrl).MaximumLength(1000).WithMessage("{PropertyName} must not exceed 2000 characters");
        }
    }
}
