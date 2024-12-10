namespace Catalog.API.Features.Categories.GetById
{
    public class GetCategoryByIdQueryHandler(AppDbContext appDbContext, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, ServiceResult<CategoryDto>>
    {
        public async Task<ServiceResult<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await appDbContext.Categories.FindAsync(request.Id, cancellationToken);

            if (category is null) return ServiceResult<CategoryDto>.Error($"The category with Id ({request.Id}) was not found!", HttpStatusCode.NotFound);

            var mappedCategory = mapper.Map<CategoryDto>(category);
            return ServiceResult<CategoryDto>.SuccessAsOk(mappedCategory);
        }
    }
}
