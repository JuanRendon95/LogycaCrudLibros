using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogycaCrudLibros.IOC
{
    public static class ConfigureCors
    {
        public static void AddCors(IServiceCollection services)
        {
            services.AddCors(options =>
            options.AddPolicy("AllowedWebApps",
            builer => builer.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
        }
    }
}
