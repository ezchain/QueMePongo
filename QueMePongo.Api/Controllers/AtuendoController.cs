using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces.Servicios;

namespace QueMePongo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtuendoController : ControllerBase
    {
        readonly IAtuendosService _atuendosService;

        public AtuendoController(IAtuendosService atuendosService)
        {
            _atuendosService = atuendosService;
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
    }
}