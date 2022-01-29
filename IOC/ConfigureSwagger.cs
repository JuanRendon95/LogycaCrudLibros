using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudLibrosLogyca.IOC
{
    public static class ConfigureSwagger
    {
        public static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"CRUD Libros Logyca {groupName}",
                    Version = groupName,
                    Description = "API para realizar las operaciones CRUD.",
                    Contact = new OpenApiContact
                    {
                        Name = "Juan Guillermo Gallego Redón",
                        Email = "guillo_jggr@hotmail.com",
                    }
                });
            });
        }
    }
}
