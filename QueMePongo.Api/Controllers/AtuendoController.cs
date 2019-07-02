using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Models;
using QueMePongo.Negocio.Sugerencias;

namespace QueMePongo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtuendoController : ControllerBase
    {
        private readonly IAtuendosService _atuendosService;
        private readonly ISugerenciasManager _sugerenciasManager;
        private readonly IClimaService _climaService;

        public AtuendoController(IAtuendosService atuendosService,
            ISugerenciasManager sugerenciasManager, IClimaService climaService)
        {
            _atuendosService = atuendosService;
            _sugerenciasManager = sugerenciasManager;
            _climaService = climaService;
        }

        [HttpGet("guardarropa/{guardarropaId}")]
        public ActionResult<IEnumerable<Atuendo>> GetAtuendosPorGuardarropa(int guardarropaId)
        {
            return ObtenerAtuendos(() =>
                _atuendosService.GenerarAtuendosPorGuardarropa(guardarropaId));
        }

        [HttpGet("usuario/{usuarioId}")]
        public ActionResult<IEnumerable<Atuendo>> GetAtuendosPorUsuario(int usuarioId)
        {
            return ObtenerAtuendos(() =>
                _atuendosService.GenerarAtuendosPorUsuario(usuarioId));
        }

        [HttpGet("usuario/{usuarioId}/{tipoDeEvento}/{ubicacion}")]
        public async Task<ActionResult<IEnumerable<Atuendo>>> GetAtuendosPorEventos(int usuarioId,
            TipoDeEvento tipoDeEvento, Ubicacion ubicacion)
        {
            var solicitud = new SolicitudDeSugerencias(
                    usuarioId,
                    tipoDeEvento,
                    ubicacion,
                    _atuendosService,
                    _climaService
                );

            _sugerenciasManager.AgregarSolicitud(solicitud);

            return Ok(await _sugerenciasManager.Procesar());
        }

        #region Métodos Privados

        private ActionResult<IEnumerable<Atuendo>> ObtenerAtuendos(Func<IEnumerable<Atuendo>> func)
        {
            try
            {
                var atuendos = func();

                if (atuendos == null)
                {
                    return NotFound();
                }

                return atuendos.ToList();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}