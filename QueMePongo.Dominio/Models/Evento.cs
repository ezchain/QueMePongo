using QueMePongo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Models
{
   public class Evento
    {
        public string Nombre { get; set; }
      //  public int Formalidad { get; set; }
        public IFrecuencia Frecuencia { get; set; }

        public Evento (string nombre, FrecuenciaEvento frecuencia)
        {
            Nombre = nombre;
            Frecuencia = new Frecuencia(frecuencia.GetAttribute<IntervaloFrecuencia>().Intervalo);
            

        }

        public bool Disponible()
        {
            return Frecuencia.TiempoTranscurrido();
        }
    }
}
