using Grace.DependencyInjection;
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
            services.AddDbContextPool<DbContext2>(options => options.UseSqlServer(Configuration.GetConnectionString("QueMePongo")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            //if (Environment.IsDevelopment())
            //    services.AddDbContext<QueMePongoDbContext>(op =>
            //        op.UseInMemoryDatabase("DevelopmentDb")
            //    );
            //else
            //    services.AddDbContext<QueMePongoDbContext>(op =>
            //       op.UseSqlServer(Configuration.GetConnectionString("Desarrollo"))
            //    );
            services.AddScoped<ISugerenciasService, SugerenciasService>();
            services.AddScoped<IClimaService, ClimaService>();
            services.AddScoped<IUsuarioService,UsuarioService>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IPrendaService, PrendaService>();
            services.AddScoped<IAtuendosService, AtuendosService>();
            services.AddScoped<IGuardarropasService, GuardarropasService>();
            services.AddScoped<IPrendasRepositorio, PrendasRepositorio>();

            services.AddScoped<IImagenHelper, ImagenHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
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
