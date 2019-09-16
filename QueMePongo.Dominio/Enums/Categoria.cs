using System;

namespace QueMePongo.Dominio.Models
{
    public enum Categoria
    {
        [Capas(0)]
        Cabeza = 0,

        [Capas(2)]
        Torso = 1,

        [Capas(0)]
        Piernas = 2,

        [Capas(0)]
        Pies = 3,

        [Capas(0)]
        Accesorio = 4
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class Capas : Attribute
    {
        public int Cantidad { get; set; }

        public Capas(int cantidad)
        {
            Cantidad = cantidad;
        }
    }
}
