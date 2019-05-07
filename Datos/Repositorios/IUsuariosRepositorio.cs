using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Repositorios
{
    public interface IUsuariosRepositorio
    {
        IList<Guardarropa> ObtenerGuardarropas();
    }
}
