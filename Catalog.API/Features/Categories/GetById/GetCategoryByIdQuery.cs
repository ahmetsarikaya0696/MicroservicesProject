namespace Catalog.API.Features.Categories.GetById
{
    public record GetCategoryByIdQuery(Guid Id) : IRequest<ServiceResult<CategoryDto>>;
}
