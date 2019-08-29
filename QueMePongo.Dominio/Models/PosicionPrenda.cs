using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Models
{
   public enum PosicionPrenda
    {   [Posicion(1)]
        Pies = 1,
        [Posicion(2)]
        Pantalon = 2,
        [Posicion(3)]
        Torso = 3,
        [Posicion(4)]
        Manos = 4,
        [Posicion(5)]
        Cabeza = 5
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
