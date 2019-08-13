using QueMePongo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Models
{
   public class Evento
    {
        public string Nombre { get; set; }
        public int Formalidad { get; set; }
        public IFrecuencia Frecuencia { get; set; }

        public Evento (string nombre,int formalidad, IFrecuencia frecuencia)
        {
            Nombre = nombre;
            Formalidad = formalidad;
            Frecuencia = frecuencia;

        }
    }
}
