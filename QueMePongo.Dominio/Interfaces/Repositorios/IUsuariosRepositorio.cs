using QueMePongo.Dominio.Models;
using System.Collections.Generic;

namespace QueMePongo.Dominio.Interfaces
{
    public interface IUsuariosRepositorio
    {
        IList<Guardarropa> ObtenerGuardarropas();
    }
}
