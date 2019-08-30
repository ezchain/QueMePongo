using QueMePongo.Dominio.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Interfaces
{
  public interface ISensibilidadLocal
    {
        IEnumerable<Atuendo> AplicarSensibilidadLocal(IEnumerable<Atuendo> atuendos);

    }
}
