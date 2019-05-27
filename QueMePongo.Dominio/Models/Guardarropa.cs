using System.Collections.Generic;

namespace QueMePongo.Dominio.Models
{
    public class Guardarropa
    {
        public Guardarropa()
        {
            Prendas = new HashSet<Prenda>();
        }

        public int Id { get; set; }
        public ICollection<Prenda> Prendas { get; set; }
    }
}
