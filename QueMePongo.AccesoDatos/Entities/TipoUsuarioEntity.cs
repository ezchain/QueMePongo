using System.ComponentModel.DataAnnotations;

namespace QueMePongo.AccesoDatos.Entities
{
    public class TipoUsuarioEntity
    {
        [Key]
        public int TipoUsuarioId { get; set; }
        public string Tipo { get; set; }
    }
}
