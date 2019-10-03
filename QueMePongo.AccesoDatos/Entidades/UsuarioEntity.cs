using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QueMePongo.AccesoDatos.Entidades
{
   public class UsuarioEntity
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string TipoUsuario { get; set; }
        public string Sensibilidad { get; set; }
        public string SensibilidadLocal { get; set; }
        public ICollection<GuardarropaEntity> Guardarropas { get; set; }
    }
}
