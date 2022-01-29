using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudLibrosLogyca.IOC
{
    public static class ConfigureContext
    {
        public static void AddContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibroContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }
    }
}
