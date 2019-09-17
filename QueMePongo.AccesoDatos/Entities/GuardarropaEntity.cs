using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueMePongo.AccesoDatos.Entities
{
    public class GuardarropaEntity
    {
        [Key]
        public int GuardarropaId { get; set; }

        public int PrendasMaximas { get; set; }

        [NotMapped]
        public IList<int> Usuarios { get; set; }

        [NotMapped]
        public ICollection<PrendaEntity> Prendas { get; set; }

    }
}
