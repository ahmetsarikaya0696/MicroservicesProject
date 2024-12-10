namespace Catalog.API.Features.Categories.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} can not be empty")
                                .Length(4, 25).WithMessage("{PropertyName} must be between {MinLength} - {MaxLength}");
        }
    }
}
