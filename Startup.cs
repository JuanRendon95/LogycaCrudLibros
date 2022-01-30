using CrudLibrosLogyca.IOC;
using LogycaCrudLibros.IOC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Repository;
using Repository.Interfaces;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudLibrosLogyca
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Agregar Swagger
            ConfigureSwagger.AddSwagger(services);
            //Agregar el contexto
            ConfigureContext.AddContext(services, Configuration);
            //Agregar el cors
            ConfigureCors.AddCors(services);
            //Agregar autommaper 
            services.AddAutoMapper(typeof(Startup));

            //Agregar el servicio del repositorio por inyeccion de dependencias
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //Agreagar los servicios del libro por inyeccion de dependencias
            services.AddScoped<ILibroService, LibroService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Agregar el middleware de swagger y swaggerui
            app.UseSwagger();
            app.UseSwaggerUI();

            //Agregar el middleware de cors
            app.UseCors("AllowedWebApps");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
