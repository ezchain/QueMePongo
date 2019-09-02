﻿using Grace.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueMePongo.AccesoDatos.Data;
using QueMePongo.AccesoDatos.Repositorios;
using QueMePongo.Api.IoC;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Repositorios;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Negocio.Helpers;
using QueMePongo.Negocio.Servicios;

namespace QueMePongo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            if (Environment.IsDevelopment())
                services.AddDbContext<QueMePongoDbContext>(op =>
                    op.UseInMemoryDatabase("DevelopmentDb")
                );
            else
                services.AddDbContext<QueMePongoDbContext>(op =>
                   op.UseSqlServer(Configuration.GetConnectionString("Desarrollo"))
                );

            services.AddScoped<IPrendaService, PrendaService>();
            services.AddScoped<IPrendasRepositorio, PrendasRepositorio>();
            services.AddScoped<IImagenHelper, ImagenHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        public void ConfigureContainer(IInjectionScope scope)
        {
            Modulo.ConfigurarServicios(scope);
        }
    }
}
