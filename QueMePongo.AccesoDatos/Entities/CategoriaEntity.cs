using System.ComponentModel.DataAnnotations;

namespace QueMePongo.AccesoDatos.Entities
{
    public class CategoriaEntity
    {
        [Key]
        public int CategoriaId { get; set; }

        public string Tipo { get; set; }
    }
}
