using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QueMePongo.Dominio.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Guardarropas = new HashSet<Guardarropa>();
        }

        public int UsuarioId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Guardarropa> Guardarropas { get; set; }
    }
}
