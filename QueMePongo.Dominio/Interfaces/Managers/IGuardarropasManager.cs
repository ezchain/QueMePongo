using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Interfaces.Managers
{
    public interface IGuardarropasManager
    {
        IList<Guardarropa> ObtenerGuardarropas();
        IList<Guardarropa> ObtenerGuardarropaPorId();
    }
}
