using QueMePongo.Dominio.Models;
using System.Collections.Generic;

namespace QueMePongo.Dominio.Interfaces.Servicios
{
    public interface IGuardarropasService
    {
        IList<Guardarropa> ObtenerGuardarropas();
        IList<Guardarropa> ObtenerGuardarropaPorId();
    }
}
