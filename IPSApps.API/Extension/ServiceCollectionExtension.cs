using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;

namespace IPSApps.API.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            // New instance every time, only configuration class needs so its ok
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "IPS Apps API", Version = "v1" });
            });
            return services;
        }
    }
}
