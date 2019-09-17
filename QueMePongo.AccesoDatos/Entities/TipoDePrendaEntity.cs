using System.ComponentModel.DataAnnotations;

namespace QueMePongo.AccesoDatos.Entities
{
    public class TipoDePrendaEntity
    {
        [Key]
        public double Temperatura { get; set; }
        public int Formalidad { get; set; }
        public int Posicion { get; set; }
        public int Nivel { get; set; }
    }
}
