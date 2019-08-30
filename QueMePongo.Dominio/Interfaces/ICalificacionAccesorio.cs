using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Interfaces
{
  public interface ICalificacionAccesorio
    {
        ISensibilidadLocal ObtenerCalificacionAccesorio(PosicionPrenda posicion);
    }
}
