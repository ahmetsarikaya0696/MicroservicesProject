using Asp.Versioning.Builder;
using Catalog.API.Features.Categories.Create;
using Catalog.API.Features.Categories.GetAll;
using Catalog.API.Features.Categories.GetById;
using Shared.Filters;

namespace Catalog.API.Features.Categories
{
    public static class CategoryEndpointsExtension
    {
        public static void AddCategoryEndpointsExtension(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/categories")
               .WithTags("Categories")
               .WithApiVersionSet(apiVersionSet)
               .CreateCategoryEndpointExtension()
               .GetAllCategoryEndpointExtension()
               .GetCategoryByIdEndpointExtension()
               .AddEndpointFilter<FluentValidationFilter>();
        }
    }
}
