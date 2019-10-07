using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QueMePongo.AccesoDatos.Entidades
{
  public  class PrendasSugerenciaEntity
    {
        [Key]
        public int Indice { get; set; }
        public int PrendaId { get; set; }
        public int SugerenciaId { get; set; }
    }
}
