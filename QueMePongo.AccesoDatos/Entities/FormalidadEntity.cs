using System.ComponentModel.DataAnnotations;

namespace QueMePongo.AccesoDatos.Entities
{
    public class FormalidadEntity
    {
        [Key]
        public int FormalidadId { get; set; }
        public string Tipo { get; set; }
    }
}
