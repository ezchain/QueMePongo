using System.Collections.Generic;
using QueMePongo.Dominio.Models;

namespace QueMePongo.Dominio.Interfaces
{
    public interface IPrendasRepositorio
    {
        IList<Prenda> ObtenerPrendas();
    }
}