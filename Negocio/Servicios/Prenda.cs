using Datos.Entidades;
using Datos.Repositorios;
using System.Collections.Generic;
using Negocio.Enums;

namespace Negocio
{
    public class Prenda : IPrenda
    {
        readonly IPrendasRepositorio _prendasRepositorio;

        public Prenda(IPrendasRepositorio prendasRepositorio)
        {
            _prendasRepositorio = prendasRepositorio;
        }

        public bool coloresValidos(EnumColor colorPrimario, EnumColor colorSecundario)
        {
            return colorPrimario != colorSecundario;
        }
    }
}
