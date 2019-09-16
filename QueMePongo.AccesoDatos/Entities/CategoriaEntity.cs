using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QueMePongo.AccesoDatos.Entities
{
    public class CategoriaEntity
    {
        [Key]
        public int CategoriaId { get; set; }

        public string Tipo { get; set; }
    }
}
