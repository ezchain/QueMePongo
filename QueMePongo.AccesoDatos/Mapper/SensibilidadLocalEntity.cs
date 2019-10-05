using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QueMePongo.AccesoDatos.Mapper
{
   public class SensibilidadLocalEntity
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Cuello { get; set; }
        public string Manos { get; set; }
        public string Cabeza { get; set; }


    }
}
