using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QueMePongo.AccesoDatos.Entities
{
    public class TelaEntity
    {
        [Key]
        public int TelaId { get; set; }

        public string Tipo { get; set; }
    }
}
