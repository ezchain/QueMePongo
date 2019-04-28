using System.Collections.Generic;
using Datos.Entidades;

namespace Negocio
{
    public interface IGuardarropa
    {
        IList<Prenda> ObtenerPrendas();
    }
}