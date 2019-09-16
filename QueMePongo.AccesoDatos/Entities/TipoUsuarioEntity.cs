using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QueMePongo.AccesoDatos.Entities
{
    public class TipoUsuarioEntity
    {
        [Key]
        public int TipoUsuarioId { get; set; }
        public string Tipo { get; set; }
    }
}
