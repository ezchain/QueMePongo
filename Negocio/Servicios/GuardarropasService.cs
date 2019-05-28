using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;

namespace QueMePongo.Negocio.Servicios
{
    public class GuardarropasService
    {
        readonly IGuardarropaRepositorio _guardarropaRepositorio;

        public GuardarropasService(IGuardarropaRepositorio guardarropaRepositorio)
        {
            _guardarropaRepositorio = guardarropaRepositorio;
        }

    }
}
