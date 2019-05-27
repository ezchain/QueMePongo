using QueMePongo.Dominio.Models;
using System.Collections.Generic;

namespace QueMePongo.Dominio.Interfaces
{
    public interface IGuardarropaRepositorio
    {
        IList<Guardarropa> ObtenerGuardarropas();
        Guardarropa ObtenerGuardarropaPorId(int id);
        Guardarropa CrearGuardarropa(Guardarropa guardarropa);
        void EditarGuardarropa(Guardarropa guardarropa);
        void EliminarGuardarropa(int id);
    }
}
