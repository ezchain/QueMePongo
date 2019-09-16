using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Models
{
    public class SensibilidadFriolento : ISensibilidad
    {
        readonly IList<ISensibilidadLocal> _SensibilidadLocal;

        public SensibilidadFriolento()
        {
            _SensibilidadLocal = new List<ISensibilidadLocal>();
            _SensibilidadLocal.Add(new SensibilidadLocalNormal());
        }
        public SensibilidadFriolento(IList<ISensibilidadLocal> sensibilidadLocal)
        {
            _SensibilidadLocal = sensibilidadLocal;
        }
        public int ObtenerSensibilidadGlobal(int capas)
        {
            return 2;
        }
        public IEnumerable<Atuendo> SensibilidadLocal(IEnumerable<Atuendo> atuendos)
        {
            IEnumerable<Atuendo> Atuendos = new List<Atuendo>();
            foreach (var sensibilidad in _SensibilidadLocal)
            {
                atuendos = sensibilidad.AplicarSensibilidadLocal(atuendos);
                Atuendos = atuendos;
            }
            return Atuendos;
        }
    }
}
