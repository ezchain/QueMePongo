using System.Collections.Generic;

namespace QueMePongo.Dominio.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Guardarropas = new HashSet<Guardarropa>();
        }

        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public ICollection<Guardarropa> Guardarropas { get; set; }
    }
}
