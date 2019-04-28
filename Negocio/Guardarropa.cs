using Datos.Entidades;
using Datos.Repositorios;
using System.Collections.Generic;

namespace Negocio
{
    public class Guardarropa : IGuardarropa
    {
        readonly IPrendasRepositorio _prendasRepositorio;

        public Guardarropa(IPrendasRepositorio prendasRepositorio)
        {
            _prendasRepositorio = prendasRepositorio;
        }

        public IList<Prenda> ObtenerPrendas()
        {
            return _prendasRepositorio.ObtenerPrendas();
        }
    }
}
