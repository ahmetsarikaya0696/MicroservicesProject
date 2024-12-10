using Asp.Versioning;
using Asp.Versioning.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Extensions
{
    public static class VersioningExtension
    {
        public static IServiceCollection AddVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }

        public static ApiVersionSet GetVersionSetExtension(this WebApplication app)
        {
            var apiVersionSet = app.NewApiVersionSet()
                                   .HasApiVersion(new ApiVersion(1, 0))
                                   .HasApiVersion(new ApiVersion(1, 1))
                                   .ReportApiVersions()
                                   .Build();
            return apiVersionSet;
        }
    }
}
