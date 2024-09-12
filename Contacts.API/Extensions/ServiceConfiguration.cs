using Contacts.API.Filters;
using Contacts.Application.Validators;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

namespace Contacts.API.Extensions
{
    public static class ServiceConfiguration
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterContactValidator>());

            builder.Services.AddControllers();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Contacts.API",
                    Version = "v1"
                });
            });

            return builder;
        }
    }
}
