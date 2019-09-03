using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Models;

namespace QueMePongo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtuendoController : ControllerBase
    {
        private readonly IAtuendosService _atuendosService;
        private readonly IUsuarioService _usuarioService;
        private readonly INotificador _notificador;
        private readonly ISugerenciasService _sugerenciasService;

        public AtuendoController(IAtuendosService atuendosService,
            IUsuarioService usuarioService,
            INotificador notificador,
            ISugerenciasService sugerenciasService)
        {
            _atuendosService = atuendosService;
            _usuarioService = usuarioService;
            _notificador = notificador;
            _sugerenciasService = sugerenciasService;
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

        [HttpGet("usuario/{Evento}")]
        public async Task<ActionResult<Sugerencia>> GenerarSugerencia(Evento evento)
        {
            try
            {
                var usuario = _usuarioService.GetUsuario(evento.UsuarioId);
                var sugerencia = await _sugerenciasService.GenerarSugerencia(evento);

                _notificador.NotificarSugerencias(usuario, evento);

                return Ok(sugerencia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("usuario/{Sugerencia}")]
        public ActionResult AceptarSugerencia(Sugerencia sugerencia)
        {
            try
            {
                _sugerenciasService.AceptarSugerencia(sugerencia);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public ActionResult CalificarSugerencia(Sugerencia sugerencia, int idUsuario, ICalificacion calificacion)
        {
            if (sugerencia.Aceptada && sugerencia.UsuarioId == idUsuario)
            {
                try
                {
                    var Usuario = _usuarioService.GetUsuario(idUsuario);
                    Usuario = calificacion.AjustarSensibilidad(Usuario);
                    _usuarioService.GuardarUsuario(Usuario);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest("La sugerencia no está aceptada por el usuario ingresado");
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