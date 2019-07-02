using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueMePongo.Negocio.Sugerencias
{
    public class SolicitudDeSugerencias : ISolicitud
    {
        private readonly int _usuarioId;
        private readonly TipoDeEvento _tipoDeEvento;
        private readonly Ubicacion _ubicacion;
        private readonly IAtuendosService _atuendosService;
        private readonly IClimaService _climaService;

        public SolicitudDeSugerencias(int usuarioId, TipoDeEvento tipoDeEvento,
            Ubicacion ubicacion, IAtuendosService atuendosService, IClimaService climaService)
        {
            _usuarioId = usuarioId;
            _tipoDeEvento = tipoDeEvento;
            _ubicacion = ubicacion;
            _atuendosService = atuendosService;
            _climaService = climaService;
        }

        public async Task<IEnumerable<Atuendo>> Ejecutar()
        {
            var clima = await _climaService.ObtenerClima(
                $"{_ubicacion.Latitud},{_ubicacion.Longitud}");

            var atuendos = _atuendosService.GenerarAtuendosPorEvento(
                    _usuarioId,
                    (decimal)clima.Temperatura,
                    _tipoDeEvento
                );

            return atuendos;
        }
    }
}
