using QueMePongo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Models
{
    public class Normal : ISensibilidad
    {
        public int ObtenerSensibilidadGlobal(int capas)
        {
            return capas;
        }
    }
    public class Friolento : ISensibilidad
    {
        public int ObtenerSensibilidadGlobal(int capas)
        {
            return 2;
        }
    }
    public class Acalorado : ISensibilidad
    {
        public int ObtenerSensibilidadGlobal(int capas)
        {
            if (capas > 1) return capas - 1;
            else return capas;
        }
    }

    public class MuyFriolento : ISensibilidad
    {
        public int ObtenerSensibilidadGlobal(int capas)
        {
            return 3;
        }

    }

    public class MuyAcalorado : ISensibilidad
    {
        public int ObtenerSensibilidadGlobal(int capas)
        {
            return 1;
        }
    }

    public class AcaloradoLocal : ISensibilidadLocal
    {
        public void ObtenerSensibilidadLocal(PosicionPrenda posicion)
        {

        }

    }
    public class FriolentoLocal : ISensibilidadLocal
    {

    }

    public class NormalLocal : ISensibilidadLocal
    {

    }
}
    
  


