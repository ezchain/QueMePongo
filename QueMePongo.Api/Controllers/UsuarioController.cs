﻿using Microsoft.AspNetCore.Mvc;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Models;
using QueMePongo.Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueMePongo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        readonly IUsuarioRepositorio _usuarioRepositorio;
        private UsuarioService usuarioService;
        private IClimaService ClimaSVC; 

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
               _usuarioRepositorio = usuarioRepositorio;
            this.usuarioService = new UsuarioService();
            ClimaSVC = new ClimaService();
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
        [HttpPost]
        [Route("AgregarGuardarropa")]
        public IActionResult AgregarGuardarropa(int idUsuario,int idGuardarropa)
        {
            try
            {
                this.usuarioService.AgregarGuardarropa(idUsuario, idGuardarropa);
                return Ok("Operacion Realizada correctamente");
            }
            catch (Exception e)
            {
            return  BadRequest(e.Message);
            }
        }

        [HttpGet("Clima")]
        public  IActionResult TestClima()
        {
            var response = ClimaSVC.ObtenerClima();
            return Ok(response.Result);
        }
    }
}