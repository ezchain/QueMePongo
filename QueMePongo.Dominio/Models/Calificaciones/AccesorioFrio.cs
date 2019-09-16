using QueMePongo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Models
{
    public class AccesorioFrio : ICalificacionAccesorio
    {
        public ISensibilidadLocal ObtenerCalificacionAccesorio(PosicionPrenda posicion)
        {
            return new SensibilidadLocalFriolento(posicion);

        }
    }
}
