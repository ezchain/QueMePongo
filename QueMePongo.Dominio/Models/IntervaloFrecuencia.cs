using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Models
{
    [AttributeUsage(AttributeTargets.Field)]
    public class IntervaloFrecuencia : Attribute
    {
        public double Intervalo { get; set; }

        public IntervaloFrecuencia(double intervalo)
        {
            Intervalo = intervalo;
        }
    }
}
