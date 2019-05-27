using QueMePongo.Dominio.Models;
using System.Collections.Generic;

namespace QueMePongo.Dominio.Interfaces.Managers
{
    public interface IGuardarropasManager
    {
        IList<Guardarropa> ObtenerGuardarropas();
        IList<Guardarropa> ObtenerGuardarropaPorId();
    }
}
