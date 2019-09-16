using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QueMePongo.AccesoDatos.Entities
{
    public class TipoDePrendaEntity
    {
        [Key]
        public int TipoDePrendaId { get; set; }

        public string Tipo { get; set; }
    }
}
