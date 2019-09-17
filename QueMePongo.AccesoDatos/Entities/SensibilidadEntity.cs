using System.ComponentModel.DataAnnotations;

namespace QueMePongo.AccesoDatos.Entities
{
    public class SensibilidadEntity
    {
        [Key]
        public int SensibilidadId { get; set; }
        public string Tipo { get; set; }
    }
}
