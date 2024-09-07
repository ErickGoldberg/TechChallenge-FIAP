using Contacts.API.Filters;
using Microsoft.OpenApi.Models;

namespace Contacts.API.Extensions
{
    public static class ServiceConfiguration
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.ConfigureDependencyInjection();
            builder.ConfigureOthersServices();

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

        public static IServiceCollection ConfigureDependencyInjection(this WebApplicationBuilder builder)
        {
            var services = builder.Services;

            //services.AddScoped<IContactRepository, ContactRepository>();

            return services;
        }

        public static IServiceCollection ConfigureOthersServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;

            //services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
            //        .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<>());

            return services;
        }
    }
}
