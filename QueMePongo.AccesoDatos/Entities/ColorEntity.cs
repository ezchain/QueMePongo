using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QueMePongo.AccesoDatos.Entities
{
    public class ColorEntity
    {
        [Key]
        public int ColorId { get; set; }

        public string ColorName { get; set; }
    }
}
