using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueMePongo.Negocio.Servicios
{
    public class SugerenciasService : ISugerenciasService
    {
        private readonly IClimaService _climaService;
        private readonly IAtuendosService _atuendosService;

        public SugerenciasService(
            IClimaService climaService,
            IAtuendosService atuendosService)
        {
            _climaService = climaService;
            _atuendosService = atuendosService;
        }

        public async Task<Sugerencia> GenerarSugerencia(Evento evento)
        {
            var clima = await _climaService
                .ObtenerClima($"{evento.Ubicacion.Latitud},{evento.Ubicacion.Longitud}");

            var atuendos = _atuendosService
                .GenerarAtuendosPorEvento((decimal)clima.Temperatura, evento);

            return ObtenerSugerenciaValida(atuendos, evento.UsuarioId);
        }

        public void AceptarSugerencia(Sugerencia sugerencia)
        {
            sugerencia.Aceptada = true;
        }

        public Sugerencia RechazarSugerencia(Sugerencia sugerencia)
        {
            throw new NotImplementedException();
        }

        private Sugerencia ObtenerSugerenciaValida(IEnumerable<Atuendo> atuendos, int idUsuario)
        {
            foreach (var combinacion in atuendos)
            {
                if (_atuendosService.ValidarSugerencia(combinacion, idUsuario))
                {
                    return new Sugerencia(combinacion);
                }
            }
            throw new Exception("No hay una sugerencia válida");
        }
    }
}
