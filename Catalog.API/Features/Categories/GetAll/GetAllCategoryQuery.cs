namespace Catalog.API.Features.Categories.GetAll
{
    public record GetAllCategoryQuery : IRequest<ServiceResult<List<CategoryDto>>>;
}
