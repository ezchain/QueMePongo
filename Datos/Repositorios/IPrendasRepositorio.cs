using System.Collections.Generic;
using Datos.Entidades;

namespace Datos.Repositorios
{
    public interface IPrendasRepositorio
    {
        IList<Prenda> ObtenerPrendas();
    }
}