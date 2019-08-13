using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.TipoUsuario;
using System.Collections.Generic;

namespace QueMePongo.Dominio.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Guardarropas = new HashSet<Guardarropa>();
            TipoUsuario = new Gratuito();
        }

        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ITipoUsuario TipoUsuario { get; set; }
        public ICollection<Guardarropa> Guardarropas { get; set; }
    }
}
