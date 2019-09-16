using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.AccesoDatos.Entities
{
    public class UsuarioEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public int TipoUsuario { get; set; }
        public ISensibilidad Sensibilidad { get; set; }
        public ICollection<Guardarropa> Guardarropas { get; set; }
    }
}
