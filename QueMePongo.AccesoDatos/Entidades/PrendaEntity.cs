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
        public string Nombre { get; set; }
        public int GuardarropaId { get; set; }
        public string Categoria { get; set; }
        public decimal Temperatura { get; set; }
        public string Formalidad { get; set; }
        public int Posicion { get; set; }
        public int Nivel { get; set; }
        public string Tela { get; set; }
        public string ColorPrimario { get; set; }
        public string ColorSecundario { get; set; }
        public byte[] Imagen { get; set; }

    }
}
