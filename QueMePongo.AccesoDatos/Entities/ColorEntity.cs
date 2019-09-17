using System.ComponentModel.DataAnnotations;

namespace QueMePongo.AccesoDatos.Entities
{
    public class ColorEntity
    {
        [Key]
        public int ColorId { get; set; }

        public string ColorName { get; set; }
    }
}
