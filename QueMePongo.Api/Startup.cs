using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueMePongo.AccesoDatos.Data;
using QueMePongo.AccesoDatos.Repositorios;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;

namespace QueMePongo
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<QueMePongoDbContext>(op =>
               op.UseSqlServer(Configuration.GetConnectionString("Desarrollo"))
            );

            services.AddScoped<Guardarropa, Guardarropa>();
            services.AddScoped<IGuardarropaRepositorio, GuardarropaRepositorio>();
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
    }
}
