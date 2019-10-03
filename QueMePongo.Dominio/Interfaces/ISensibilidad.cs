using QueMePongo.Dominio.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Interfaces
{
    public interface ISensibilidad
    {
        string GetNombre();
        int ObtenerSensibilidadGlobal(int capas);
        IEnumerable<Atuendo> SensibilidadLocal(IEnumerable<Atuendo> atuendos);

    }
}
