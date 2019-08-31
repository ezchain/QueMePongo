using QueMePongo.Dominio.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Models
{
  public class Sugerencia
    {
        public int IDSugerencia { get; set; }
        public Atuendo Atuendo { get; set; }
        public bool Aceptada { get; set; }
        public int IDUsuario { get; set; }
        public double CalorTotal { get; set; }

        public Sugerencia(Atuendo atuendo)
        {
            Atuendo = atuendo;
            CalorTotal = atuendo.CalorTotal();
        }

    }
}
