using System;

namespace QueMePongo.Dominio.Models
{
    public enum TipoDeEvento
    {
        [NivelDeFormalidad(5)]
        SalirConAmigos = 1,

        [NivelDeFormalidad(10)]
        SalirConFamilia = 2,

        [NivelDeFormalidad(15)]
        IrATrabajar = 3
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class NivelDeFormalidad : Attribute
    {
        public int Nivel { get; set; }

        public NivelDeFormalidad(int nivel)
        {
            Nivel = nivel;
        }
    }
}
