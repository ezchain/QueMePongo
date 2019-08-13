using System;

namespace QueMePongo.Dominio.Models
{
    public enum TipoDeEvento
    {
        [NivelDeFormalidad(1)]
        SalirConAmigos = 1,

        [NivelDeFormalidad(2)]
        SalirConFamilia = 2,

        [NivelDeFormalidad(3)]
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
