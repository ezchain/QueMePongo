using System.ComponentModel.DataAnnotations;

namespace QueMePongo.AccesoDatos.Entities
{
    public class FrecuenciaEventoEntity
    {
        [Key]
        public int FrecuenciaId { get; set; }

        public string Tipo { get; set; }
    }
}
