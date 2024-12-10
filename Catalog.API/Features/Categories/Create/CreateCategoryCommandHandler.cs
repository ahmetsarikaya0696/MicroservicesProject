namespace Catalog.API.Features.Categories.Create
{
    public class CreateCategoryCommandHandler(AppDbContext appDbContext) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
    {
        public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryExist = await appDbContext.Categories.AnyAsync(x => x.Name == request.Name);

            if (categoryExist)
            {
                return ServiceResult<CreateCategoryResponse>.Error("Category name already exist", $"The category name '{request.Name}' already exist", HttpStatusCode.BadRequest);
            }

            var category = new Category
            {
                Id = NewId.NextSequentialGuid(),
                Name = request.Name
            };

            await appDbContext.Categories.AddAsync(category, cancellationToken);
            await appDbContext.SaveChangesAsync();

            return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(new CreateCategoryResponse(category.Id), $"api/categories/{category.Id}");
        }
    }
}
