using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QueMePongo.AccesoDatos.Entidades
{
   public class GuardarropasUsuariosEntity
    {
        [Key]
        public int IDGuardarropa { get; set; }
        public int UsuarioId { get; set; }
    }
}
