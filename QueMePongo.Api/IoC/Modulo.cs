using Grace.DependencyInjection;
using QueMePongo.AccesoDatos.Repositorios;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Interfaces.Validacion;
using QueMePongo.Negocio.Servicios;
using QueMePongo.Negocio.Validaciones;

namespace QueMePongo.Api.IoC
{
    public static class Modulo
    {
        public static void ConfigurarServicios(IInjectionScope scope)
        {
            scope.Configure(s =>
            {
                s.Export<GuardarropaRepositorio>().As<IGuardarropaRepositorio>();
                s.Export<UsuarioRepositorio>().As<IUsuarioRepositorio>();

                s.Export<AtuendosService>().As<IAtuendosService>();
                s.Export<GuardarropasService>().As<IGuardarropasService>();

                s.Export<EstrategiaValidacion>().As<IContextoValidacion>();
            });
        }
    }
}
