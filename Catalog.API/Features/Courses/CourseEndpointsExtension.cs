using Asp.Versioning.Builder;
using Catalog.API.Features.Courses.Create;
using Catalog.API.Features.Courses.Delete;
using Catalog.API.Features.Courses.GetAll;
using Catalog.API.Features.Courses.GetAllByUserId;
using Catalog.API.Features.Courses.GetById;
using Catalog.API.Features.Courses.Update;
using Shared.Filters;

namespace Catalog.API.Features.Courses
{
    public static class CourseEndpointsExtension
    {
        public static void AddCourseEndpointsExtension(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/courses")
               .WithTags("Courses")
               .WithApiVersionSet(apiVersionSet)
               .CreateCourseEndpointExtension()
               .GetAllCourseEndpointExtension()
               .GetCourseByIdEndpointExtension()
               .UpdateCourseCommandEndpointExtension()
               .DeleteCourseEndpointExtension()
               .GetAllCourseByUserIdEndpointExtension()
               .AddEndpointFilter<FluentValidationFilter>();
        }
    }
}
