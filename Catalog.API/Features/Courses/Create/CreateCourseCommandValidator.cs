namespace Catalog.API.Features.Courses.Create
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} can not be empty")
                                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 200 characters");

            RuleFor(x => x.Description).NotEmpty().WithMessage("{PropertyName} can not be empty")
                                       .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 2000 characters");

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

            RuleFor(x => x.ImageUrl).MaximumLength(1000).WithMessage("{PropertyName} must not exceed 2000 characters");

            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("{PropertyName} can not be empty");
        }
    }
}
