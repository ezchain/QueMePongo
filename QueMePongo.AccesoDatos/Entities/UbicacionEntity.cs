using System.ComponentModel.DataAnnotations;

namespace QueMePongo.AccesoDatos.Entities
{
    public class UbicacionEntity
    {
        [Key]
        public int UbicacionId { get; set; }

        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}
