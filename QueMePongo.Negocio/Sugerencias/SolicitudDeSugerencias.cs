using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueMePongo.Negocio.Sugerencias
{
    public class SolicitudDeSugerencias : ISolicitud
    {
        private readonly int _usuarioId;
        private readonly Evento _evento;
        private readonly Ubicacion _ubicacion;
        private readonly IAtuendosService _atuendosService;
        private readonly IClimaService _climaService;



        public SolicitudDeSugerencias(int usuarioId, Evento evento, IAtuendosService atuendosService, IClimaService climaService)
        {
            _usuarioId = usuarioId;
            _evento = evento;
            _ubicacion = evento.Ubicacion;
            _atuendosService = atuendosService;
            _climaService = climaService;
        }

        public async Task<IEnumerable<Atuendo>> Ejecutar()
        {
            if (_evento.Disponible())
            {
                var clima = await _climaService.ObtenerClima(
                    $"{_ubicacion.Latitud},{_ubicacion.Longitud}");

                var atuendos = _atuendosService.GenerarAtuendosPorEvento(
                        _usuarioId,
                        (decimal)clima.Temperatura,
                        _evento
                    );
                
                return atuendos;
            }
            throw new Exception("El evento " + _evento.Nombre + " no esta disponible");
        }
    }
}
