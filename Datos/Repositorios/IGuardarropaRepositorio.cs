using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Repositorios
{
    public interface IGuardarropaRepositorio
    {
        IList<Guardarropa> ObtenerGuardarropas();
    }
}
