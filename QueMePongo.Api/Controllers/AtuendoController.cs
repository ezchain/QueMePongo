using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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
       // private readonly INotificador _notificador;
        private readonly ISugerenciasService _sugerenciasService;

        public AtuendoController(IAtuendosService atuendosService,
            IUsuarioService usuarioService,
            ISugerenciasService sugerenciasService)
        {
            _atuendosService = atuendosService;
            _usuarioService = usuarioService;
            
            _sugerenciasService = sugerenciasService;
        }

        [HttpGet("guardarropa/{guardarropaId}")]
        public ActionResult<IEnumerable<Atuendo>> GetAtuendosPorGuardarropa(int guardarropaId)
        {
            return Ok(ObtenerAtuendos(() =>
                _atuendosService.GenerarAtuendosPorGuardarropa(guardarropaId)));
        }

        [HttpGet("usuarioAtuendos/{usuarioId}")]
        public ActionResult<IEnumerable<Atuendo>> GetAtuendosPorUsuario(int usuarioId)
        {
            return Ok(ObtenerAtuendos(() =>
                _atuendosService.GenerarAtuendosPorUsuario(usuarioId)));
        }

        [HttpPost("usuario/GenerarSugerencia")]
        [EnableCors("AllowOrigin")]
        public  ActionResult<Sugerencia> GenerarSugerencia([FromBody]Evento evento)
        {
      
            var sugerencias = new List<Sugerencia>();
            var atuendos = ObtenerAtuendos(() =>
                _atuendosService.GenerarAtuendosPorUsuario(evento.UsuarioId));

            foreach(var x in atuendos)
            {
                sugerencias.Add(new Sugerencia(x)); 
            }
            return Ok(sugerencias);
            }

        [HttpPost("usuario/AceptarSugerencia")]
        [EnableCors("AllowOrigin")]
        public ActionResult AceptarSugerencia([FromBody]Sugerencia sugerencia)
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
        //ARREGLAR
        [HttpGet("usuario/calificar/{sugerenciaId}/{calificacion}")]
        [EnableCors("AllowOrigin")]
        public ActionResult CalificarSugerencia(int sugerenciaId, int calificacion)
        {
            return Ok();
        //    if (sugerencia.Aceptada && sugerencia.UsuarioId == idUsuario)
        //    {
        //        try
        //        {
        //            var Usuario = _usuarioService.GetUsuario(idUsuario);
        //            Usuario = calificacion.AjustarSensibilidad(Usuario);
        //            _usuarioService.ModificarUsuario(Usuario);
        //            return Ok();
        //        }
        //        catch (Exception e)
        //        {
        //            return BadRequest(e.Message);
        //        }
        //    }
        //    return BadRequest("La sugerencia no está aceptada por el usuario ingresado");
        }

        #region Métodos Privados

        private IList<Atuendo> ObtenerAtuendos(Func<IEnumerable<Atuendo>> func)
        {
            try
            {
                var atuendos = func();

                if (atuendos == null)
                {
                    return null;
                }

                return atuendos.ToList();
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        #endregion
    }
}