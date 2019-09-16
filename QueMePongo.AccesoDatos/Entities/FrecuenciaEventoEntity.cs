using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QueMePongo.AccesoDatos.Entities
{
    public class FrecuenciaEventoEntity
    {
        [Key]
        public int FrecuenciaId { get; set; }

        public string Tipo { get; set; }
    }
}
