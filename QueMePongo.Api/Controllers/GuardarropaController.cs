using Microsoft.AspNetCore.Mvc;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.Controllers
{
    [Route("api/[controller]")]
    public class GuardarropaController : ControllerBase
    {
        readonly IGuardarropasService _guardarropasService;

        public GuardarropaController(IGuardarropasService guardarropasService)
        {
            _guardarropasService = guardarropasService;
        }

        // GET: api/guardarropa
        [HttpGet]
        public ActionResult<IEnumerable<Guardarropa>> GetGuardarropaItems()
        {
            return _guardarropasService.ObtenerGuardarropas().ToList();
        }

        // GET: api/guardarropa/2
        [HttpGet("{id}")]
        public ActionResult<Guardarropa> GetGuardarropaItem(int id)
        {
            var guardarropa = _guardarropasService.ObtenerGuardarropaPorId(id);

            if (guardarropa == null)
            {
                return NotFound();
            }

            return guardarropa;
        }

        // POST: api/guardarropa
        [HttpPost]
        public ActionResult<Guardarropa> PostGuardarropaItem([FromBody]Guardarropa guardarropa)
        {
            try
            {
                _guardarropasService.CrearGuardarropa(guardarropa);

                return CreatedAtAction(
                    nameof(GetGuardarropaItem),
                    new { id = guardarropa.GuardarropaId }, guardarropa);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/guardarropa/2
        [HttpPut("{id}")]
        public IActionResult PutGuardarropaItem(int id, [FromBody]Guardarropa guardarropa)
        {
            try
            {
                if (id != guardarropa.GuardarropaId)
                {
                    return BadRequest();
                }

                _guardarropasService.EditarGuardarropa(guardarropa);

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/guardarropa/2
        [HttpDelete("{id}")]
        public IActionResult DeleteGuardarropa(int id)
        {
            try
            {
                _guardarropasService.EliminarGuardarropa(id);

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}