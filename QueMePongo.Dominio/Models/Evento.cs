﻿using QueMePongo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Models
{
   public class Evento
    {
        public int IdEvento { get; set; }
        public string Nombre { get; set; }
        public int Formalidad { get; set; }
        public IFrecuencia Frecuencia { get; set; }

        public Evento (string nombre, int formalidad, FrecuenciaEvento frecuencia)
        {
            Nombre = nombre;
            Formalidad = formalidad;
            Frecuencia = new Frecuencia(frecuencia.GetAttribute<IntervaloFrecuencia>().Intervalo);
            

        }

        public bool Disponible()
        {
            return Frecuencia.TiempoTranscurrido();
        }
    }
}
