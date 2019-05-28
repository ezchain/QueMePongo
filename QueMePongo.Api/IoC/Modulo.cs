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
                s.Export<IGuardarropaRepositorio>().As<GuardarropaRepositorio>();
                s.Export<IUsuarioRepositorio>().As<UsuarioRepositorio>();

                s.Export<IAtuendosService>().As<AtuendosService>();
                s.Export<IGuardarropasService>().As<GuardarropasService>();

                s.Export<IEstrategiaValidacion>().As<EstrategiaValidacion>();
            });
        }
    }
}
