using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
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
        private readonly IUsuarioService _usuarioService;
        private readonly ISugerenciasManager _sugerenciasManager;
        private readonly IClimaService _climaService;
        private readonly INotificador _notificador;

        public AtuendoController(IAtuendosService atuendosService,
            ISugerenciasManager sugerenciasManager, IClimaService climaService, INotificador notificador,IUsuarioService usuarioService)
        {
            _atuendosService = atuendosService;
            _sugerenciasManager = sugerenciasManager;
            _climaService = climaService;
            _notificador = notificador;
            _usuarioService = usuarioService;
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

        [HttpGet("usuario/{usuarioId}/{Evento}")]
        public async Task<ActionResult<Sugerencia>> GenerarSugerencia(int usuarioId, Evento evento)
        {
            var solicitud = new SolicitudDeSugerencias(usuarioId, evento,
                _atuendosService, _climaService );
            var Usuario = _usuarioService.GetUsuario(usuarioId);

            try {        
                _sugerenciasManager.AgregarSolicitud(solicitud);
                var result = await _sugerenciasManager.Procesar();
                Sugerencia sugerencia = ObtenerSugerenciaValida(result, usuarioId);
                _notificador.NotificarSugerencias(Usuario, evento);
                return Ok(sugerencia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }  
        }
        [HttpGet("usuario/{usuarioId}/{Sugerencia}")]
        public ActionResult AceptarSugerencia(Sugerencia sugerencia, int IDUsuario)
        {
            try
            {
                _sugerenciasManager.AceptarSugerencia(sugerencia, IDUsuario);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public ActionResult CalificarSugerencia(Sugerencia sugerencia,int idUsuario, ICalificacion calificacion)
        {
            if(sugerencia.Aceptada && sugerencia.IDUsuario==idUsuario)
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

        private Sugerencia ObtenerSugerenciaValida(IEnumerable<Atuendo> atuendos,int idUsuario)
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