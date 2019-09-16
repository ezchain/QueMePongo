using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QueMePongo.AccesoDatos.Entities
{
    public class UbicacionEntity
    {
        [Key]
        public int UbicacionId { get; set; }

        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}
