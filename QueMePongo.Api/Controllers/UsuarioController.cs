using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QueMePongo.AccesoDatos.Repositorios;
using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Models;
using QueMePongo.Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IUsuarioService _usuarioService;
        private readonly EventosRepositorio eventosService;
        private readonly IClimaService _climaSVC;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio,
            IUsuarioService usuarioService, IClimaService climaSVC)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _usuarioService = usuarioService;
            _climaSVC = new ClimaService();
            eventosService = new EventosRepositorio();
        }

        // GET: api/Usuario
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarioItems()
        {
            return _usuarioRepositorio.ObtenerUsuarios().ToList();
        }

        // GET: api/Usuario/2
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public ActionResult<Usuario> GetUsuarioItem(int id)
        {
            Usuario usuario1 = new Usuario()
            {
                Username = "Lucas",
                Mail = "asd",
                Password = "asd",
                UsuarioId = 1,

            };
            Guardarropa guardarropa1 = new Guardarropa()
            {
                GuardarropaId = 1,
                PrendasMaximas = 100,

            };
            usuario1.Guardarropas.Add(guardarropa1);
            return Ok(usuario1);
            //var Usuario = _usuarioRepositorio.ObtenerUsuario(id);

            //if (Usuario == null)
            //{
            //    return NotFound();
            //}

            //return Usuario;
        }

        // POST: api/Usuario
        [HttpPost]
        [Route("AgregarUsuario")]
        public ActionResult<Usuario> PostUsuarioItem([FromBody]Usuario Usuario)
        {
            _usuarioRepositorio.CrearUsuario(Usuario);

            return CreatedAtAction(
                nameof(GetUsuarioItem),
                new { id = Usuario.UsuarioId }, Usuario);
        }

        // PUT: api/Usuario/2
        [HttpPut("{id}")]
        public IActionResult PutUsuarioItem(int id, [FromBody]Usuario Usuario)
        {
            if (id != Usuario.UsuarioId)
            {
                return BadRequest();
            }

            _usuarioRepositorio.UpdateUsuario(Usuario);

            return NoContent();
        }

        // DELETE: api/Usuario/2
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuarioItem(int id)
        {
            try
            {
                _usuarioService.EliminarUsuario(id);

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("AgregarGuardarropa")]
        [EnableCors("AllowOrigin")]
        public IActionResult AgregarGuardarropa(int idUsuario, int idGuardarropa)
        {
            try
            {
                _usuarioService.AgregarGuardarropa(idUsuario, idGuardarropa);
                return Ok("Operacion Realizada correctamente");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("AgregarEvento")]
        [EnableCors("AllowOrigin")]
        public IActionResult AgregarEvento([FromBody]Evento evento)
        {
            try
            {
                eventosService.CrearEvento(evento);
                return Ok("Operacion Realizada correctamente");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerEventos")]
        [EnableCors("AllowOrigin")]
        public IActionResult ObtenerEventos()
        {
            ICollection<Evento> eventos = new List<Evento>();

            Evento evento = new Evento()
            {
                Nombre = "evento1",
                FechaInicio = new DateTime(2019, 11, 01),
                Frecuencia = new Frecuencia() { Nombre="Unico"}
        };
        Evento evento2 = new Evento()
        {
            Nombre = "Evento2",
            FechaInicio = new DateTime(2019, 11, 01),
            Frecuencia = new Frecuencia() { Nombre = "Unico" }
        };
            eventos.Add(evento);
            eventos.Add(evento2);

            return Ok(eventos);
    }



    [HttpGet]
    [Route("EliminarEvento/{id}")]
    public IActionResult EliminarEvento(int id)
    {
        try
        {
            eventosService.DeleteEvento(id);
            return Ok("Operacion Realizada correctamente");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }



}
}