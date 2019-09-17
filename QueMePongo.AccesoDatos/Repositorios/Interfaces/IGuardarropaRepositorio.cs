using QueMePongo.AccesoDatos.Entities;
using System.Collections.Generic;

namespace QueMePongo.AccesoDatos.Repositorios.Interfaces
{
    public interface IGuardarropaRepositorio
    {
        IEnumerable<GuardarropaEntity> ObtenerGuardarropas();
        GuardarropaEntity ObtenerGuardarropaPorId(int id);
        GuardarropaEntity CrearGuardarropa(GuardarropaEntity guardarropa);
        void EditarGuardarropa(GuardarropaEntity guardarropa);
        void EliminarGuardarropa(int id);
        void AgregarPrenda(int idGuardarropa, PrendaEntity prenda);
    }
}
