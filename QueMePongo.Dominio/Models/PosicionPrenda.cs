using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Models
{
   public enum PosicionPrenda
    {
        [Posicion(4)]
        Manos = 4,
        [Posicion(5)]
        Cuello = 5,
        [Posicion(6)]
        Cabeza = 6
      
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class Posicion : Attribute
    {
        public int PosicionPrenda { get; set; }

        public Posicion(int posicion)
        {
            PosicionPrenda = posicion;
        }
    }
}
