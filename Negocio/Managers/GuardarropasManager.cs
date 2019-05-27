using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;

namespace QueMePongo.Negocio.Managers
{
    public class GuardarropasManager
    {
        readonly IGuardarropaRepositorio _guardarropaRepositorio;

        public GuardarropasManager(IGuardarropaRepositorio guardarropaRepositorio)
        {
            _guardarropaRepositorio = guardarropaRepositorio;
        }

    }
}
