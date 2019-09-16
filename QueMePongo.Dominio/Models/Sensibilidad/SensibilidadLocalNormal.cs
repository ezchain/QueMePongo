using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Models
{
    public class SensibilidadLocalNormal :ISensibilidadLocal
    {
        public IEnumerable<Atuendo> AplicarSensibilidadLocal(IEnumerable<Atuendo> atuendos)
        {
            return atuendos;
        }
    }
}
