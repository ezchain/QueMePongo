using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueMePongo.AccesoDatos.Data;
using QueMePongo.Dominio.Models;

namespace QueMePongo.Api.Controllers
{
    public class BaseTestController : Controller
    {
        [Route("api/Base/Test")]
        public IActionResult Index()
        {
            using (var context = new QueMePongoDbContext())
            {

                var std = new Prenda()
                {
                    PrendaId = 2,
                    GuardarropaId = 2
                };

                context.Prendas.Add(std);
                context.SaveChanges();
                return Ok("asd");
            }
        }
    }
}