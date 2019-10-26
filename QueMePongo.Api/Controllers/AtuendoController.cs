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
            return ObtenerAtuendos(() =>
                _atuendosService.GenerarAtuendosPorGuardarropa(guardarropaId));
        }

        [HttpGet("usuario/{usuarioId}")]
        public ActionResult<IEnumerable<Atuendo>> GetAtuendosPorUsuario(int usuarioId)
        {
            return ObtenerAtuendos(() =>
                _atuendosService.GenerarAtuendosPorUsuario(usuarioId));
        }

        [HttpPost("usuario/GenerarSugerencia")]
        [EnableCors("AllowOrigin")]
        public  ActionResult<Sugerencia> GenerarSugerencia([FromBody]Evento evento)
        {
            Prenda prenda = new Prenda()
            {
                Nombre = "lompa",
                Categoria = Categoria.Piernas,
                ColorPrimario = Color.Azul,
                ColorSecundario = Color.Marron,
                GuardarropaId = 1,
                Tela = Tela.Cuero,
                PrendaId = 1,


            };
            Prenda prenda2 = new Prenda()
            {
                Categoria = Categoria.Pies,
                ColorPrimario = Color.Azul,
                GuardarropaId = 1,
                Tela = Tela.Cuero,
                PrendaId = 1,
                Tipo = new TipoDePrenda()
                {
                    Formalidad = Formalidad.Formal,
                    Nivel = 1,
                    Posicion = 2,
                    Temperatura = 10
                }

            };
            Prenda prenda3 = new Prenda()
            {
                Categoria = Categoria.Piernas,
                ColorPrimario = Color.Azul,
                GuardarropaId = 1,
                Tela = Tela.Cuero,
                PrendaId = 1,
                Tipo = new TipoDePrenda()
                {
                    Formalidad = Formalidad.Formal,
                    Nivel = 1,
                    Posicion = 2,
                    Temperatura = 10
                }
            };
            Atuendo atuendo = new Atuendo();
            atuendo.Prendas.Add(prenda);
            atuendo.Prendas.Add(prenda2);
            atuendo.Prendas.Add(prenda3);
            Sugerencia sugerencia = new Sugerencia(atuendo);

            return Ok(sugerencia);

                //    try
                //    {
                //        var usuario = _usuarioService.GetUsuario(evento.UsuarioId);
                //        var sugerencia = await _sugerenciasService.GenerarSugerencia(evento);

                //        _notificador.NotificarSugerencias(usuario, evento);

                //        return Ok(sugerencia);
                //    }
                //    catch (Exception ex)
                //    {
                //        return BadRequest(ex.Message);
                //    }
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