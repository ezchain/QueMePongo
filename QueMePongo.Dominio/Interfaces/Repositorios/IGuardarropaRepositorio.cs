using QueMePongo.Dominio.Models;
using System.Collections.Generic;

namespace QueMePongo.Dominio.Interfaces
{
    public interface IGuardarropaRepositorio
    {
        IEnumerable<Guardarropa> ObtenerGuardarropas();
        Guardarropa ObtenerGuardarropaPorId(int id);
        Guardarropa CrearGuardarropa(Guardarropa guardarropa);
        void EditarGuardarropa(Guardarropa guardarropa);
        void EliminarGuardarropa(int id);
        void AgregarPrenda(int idGuardarropa, Prenda prenda);
        void AgregarGuardarropa(int idUsuario, int idGuardarropa);
    }
}
