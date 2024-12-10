﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Extensions
{
    public static class CommonServicesExtension
    {
        public static IServiceCollection AddCommonServicesExtension(this IServiceCollection services, Type type)
        {
            services.AddHttpContextAccessor();

            services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining(type));

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining(type);

            services.AddAutoMapper(type);

            return services;
        }
    }
}