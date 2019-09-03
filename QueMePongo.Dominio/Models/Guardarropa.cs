using System.Collections.Generic;

namespace QueMePongo.Dominio.Models
{
    public class Guardarropa
    {
        public Guardarropa()
        {
            Prendas = new HashSet<Prenda>();
            Usuarios = new List<int>();
        }

        public int GuardarropaId { get; set; }
        public IList<int> Usuarios { get; set; }
        public ICollection<Prenda> Prendas { get; set; }
        public int PrendasMaximas { get; set; }
    }
}
