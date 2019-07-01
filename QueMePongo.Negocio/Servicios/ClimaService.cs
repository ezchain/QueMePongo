using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Negocio.ProveedoresDeClima;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueMePongo.Negocio.Servicios
{
    public class ClimaService : IClimaService
    {
        public async Task<Clima> ObtenerClima(string coordenadas)
        {
            try
            {
                var proveedores = ObtenerProveedores(coordenadas);

                var tasks = proveedores.Select(p => p.ObtenerClima());

                var taskCompletada = await Task.WhenAny(tasks);

                return await taskCompletada;
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error al consultar a los proveedores de clima");
            }
        }

        private IList<ProveedorDeClimaBase> ObtenerProveedores(string coordenadas)
        {
            return new List<ProveedorDeClimaBase>
            {
                new ProveedorApiXU(coordenadas),
                new ProveedorDarkSky(coordenadas)
            };
        }
    }
}
