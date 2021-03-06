﻿using QueMePongo.Dominio.Models;
using System.Collections.Generic;

namespace QueMePongo.Dominio.Interfaces.Servicios
{
    public interface IGuardarropasService
    {
        IEnumerable<Guardarropa> ObtenerGuardarropas();
        Guardarropa ObtenerGuardarropaPorId(int id);
        Guardarropa CrearGuardarropa(Guardarropa guardarropa);
        void EditarGuardarropa(Guardarropa guardarropa);
        void EliminarGuardarropa(int id);
    }
}
