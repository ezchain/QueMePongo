using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueMePongo.Negocio.Sugerencias
{
    public class SugerenciasManager : ISugerenciasManager
    {
        private Queue<ISolicitud> _colaDeSolicitudes;
        private readonly IAtuendosService _atuendosService;
        private readonly IClimaService _climaService;

        public void CrearSolicitud(int usuarioId, Ubicacion ubicacion, TipoDeEvento tipoDeEvento)
        {
            _colaDeSolicitudes.Enqueue(
                    new SolicitudDeSugerencias(
                        usuarioId,
                        tipoDeEvento,
                        ubicacion,
                        _atuendosService,
                        _climaService)
                );
        }

        public async Task<IEnumerable<Atuendo>> Procesar()
        {
            var evento = _colaDeSolicitudes.Dequeue();

            return await evento.Ejecutar();
        }
    }
}
