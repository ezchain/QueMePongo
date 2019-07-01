using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueMePongo.Negocio.EventosDeUsuario
{
    public class Evento
    {
        private readonly Usuario _usuario;
        private readonly TipoDeEvento _tipoDeEvento;
        private readonly Ubicacion _ubicacion;
        private readonly IAtuendosService _atuendosService;
        private readonly IClimaService _climaService;

        public Evento(Usuario usuario, TipoDeEvento tipoDeEvento, Ubicacion ubicacion,
            IAtuendosService atuendosService, IClimaService climaService)
        {
            _usuario = usuario;
            _tipoDeEvento = tipoDeEvento;
            _ubicacion = ubicacion;
            _atuendosService = atuendosService;
            _climaService = climaService;
        }

        public async Task<IEnumerable<Atuendo>> Ejecutar()
        {
            var atuendos = _atuendosService
                .GenerarAtuendosPorUsuario(_usuario.UsuarioId);

            var clima = await _climaService.ObtenerClima(
                $"{_ubicacion.Latitud},{_ubicacion.Longitud}");

            return null;
        }
    }
}
