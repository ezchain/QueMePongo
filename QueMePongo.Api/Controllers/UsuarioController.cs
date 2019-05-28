using Microsoft.AspNetCore.Mvc;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        // GET: api/Usuario
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarioItems()
        {
            return _usuarioRepositorio.ObtenerUsuarios().ToList();
        }

        // GET: api/Usuario/2
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuarioItem(int id)
        {
            var Usuario = _usuarioRepositorio.ObtenerUsuarioPorId(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Usuario;
        }

        // POST: api/Usuario
        [HttpPost]
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

            _usuarioRepositorio.EditarUsuario(Usuario);

            return NoContent();
        }

        // DELETE: api/Usuario/2
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuarioItem(int id)
        {
            try
            {
                _usuarioRepositorio.EliminarUsuario(id);

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}