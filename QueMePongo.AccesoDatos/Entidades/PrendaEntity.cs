using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QueMePongo.AccesoDatos.Entidades
{
   public class PrendaEntity
    {
        [Key]
        public int PrendaId { get; set; }
        public int GuardarropaId { get; set; }
        public string Categoria { get; set; }
        public int Tipo { get; set; }
        public string Tela { get; set; }
        public string ColorPrimario { get; set; }
        public string ColorSecundario { get; set; }
        public byte[] Imagen { get; set; }

    }
}
