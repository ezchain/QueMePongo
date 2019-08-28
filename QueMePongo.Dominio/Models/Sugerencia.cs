using QueMePongo.Dominio.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Models
{
  public class Sugerencia
    {
        public int IDSugerencia { get; set; }
        public IEnumerable<Atuendo> Atuendos { get; set; }
        public bool Aceptada { get; set; }
        public int IDUsuario { get; set; }


        public Sugerencia(IEnumerable<Atuendo> atuendos)
        {
            Atuendos = atuendos;
        }
    }
}
