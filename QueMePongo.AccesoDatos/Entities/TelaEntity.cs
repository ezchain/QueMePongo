using System.ComponentModel.DataAnnotations;

namespace QueMePongo.AccesoDatos.Entities
{
    public class TelaEntity
    {
        [Key]
        public int TelaId { get; set; }

        public string Tipo { get; set; }
    }
}
