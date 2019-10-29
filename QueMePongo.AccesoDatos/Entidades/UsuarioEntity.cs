using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QueMePongo.AccesoDatos.Entidades
{
   public class UsuarioEntity
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int UsuarioId { get; set; }
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string TipoUsuario { get; set; }
        public string Sensibilidad { get; set; }
   
    }
}
