using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Models;

namespace QueMePongo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrendaController : ControllerBase
    {
        private readonly IPrendaService prendaService;

        public PrendaController(IPrendaService prendaService)
        {
            this.prendaService = prendaService;
        }
        // GET: api/Prenda
        [HttpGet]
        public ActionResult<IEnumerable<Prenda>> Get()
        {
            return prendaService.GetPrendas().ToList();
        }

        // GET: api/Prenda/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Prenda> Get(int id)
        {
            return prendaService.GetPrenda(id);
        }

        // POST: api/Prenda
        [HttpPost]
        public IActionResult Post([FromBody] PrendaDTO prenda)
        {
            prendaService.AddPrenda(prenda);
            return Ok();
        }

        // PUT: api/Prenda/5
        [HttpPut("{id}")]
        public void Put([FromBody] Prenda prenda)
        {
            prendaService.UpdatePrenda(prenda);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            prendaService.DeletePrenda(id);
        }
    }
}
