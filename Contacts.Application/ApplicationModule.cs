using Contacts.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices();
            return services;
        }


        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();

            return services;
        }




    }
}

