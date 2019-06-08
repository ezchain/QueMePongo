using System.Collections.Generic;

namespace QueMePongo.Dominio.Models
{
    public class Guardarropa
    {
        public Guardarropa()
        {
            Prendas = new HashSet<Prenda>();
        }

        public int GuardarropaId { get; set; }
        public int UsuarioId { get; set; }
        public ICollection<Prenda> Prendas { get; set; }
        public int PrendasMaximas { get; set; }
    }
}
