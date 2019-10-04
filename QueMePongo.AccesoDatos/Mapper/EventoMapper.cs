using QueMePongo.AccesoDatos.Entidades;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.AccesoDatos.Mapper
{
    public static class EventoMapper
    {
        public static EventoEntity MapEntity(Evento evento)
        {
            return new EventoEntity()
            {
                EventoId = evento.EventoId,
                FechaInicio = evento.FechaInicio,
                UsuarioId = evento.UsuarioId,
                Nombre = evento.Nombre,
                Latitud = evento.Ubicacion.Latitud,
                Longitud = evento.Ubicacion.Longitud,
                Frecuencia = evento.Frecuencia.Nombre,
                Formalidad = ObtenerFormalidad(evento.Formalidad)
            };

        }

        public static Evento MapModel(EventoEntity entidad)
        {
            Ubicacion ubicacion = new Ubicacion()
            {
                Latitud = entidad.Latitud,
                Longitud = entidad.Longitud
            };
            Frecuencia frecuencia = new Frecuencia(ObtenerDiasFrecuencia(entidad.Frecuencia));
       
            return new Evento()
            {
                EventoId = entidad.EventoId,
                FechaInicio = entidad.FechaInicio,
                Nombre = entidad.Nombre,
                UsuarioId = entidad.UsuarioId,
                Ubicacion = ubicacion,
                Formalidad = ObtenerFormalidadEnum(entidad.Formalidad),
                Frecuencia = frecuencia
            };
        }
        private static string ObtenerFormalidad(Formalidad formalidad)
        {
            if (formalidad == Formalidad.Normal) return "Normal";
            if (formalidad == Formalidad.Formal) return "Formal";
            if (formalidad == Formalidad.Distendido) return "Distendido";
            return String.Empty;
        }

        private static Formalidad ObtenerFormalidadEnum(string formalidad)
        {
            if (formalidad.Equals("Normal")) return Formalidad.Normal;
            if (formalidad.Equals("Formal")) return Formalidad.Formal;
            return Formalidad.Distendido;
            
        }

        private static double ObtenerDiasFrecuencia(string frecuencia)
        {
            if (frecuencia.Equals("Anual")) return 365;
            if (frecuencia.Equals("Mensual")) return 31;
            if (frecuencia.Equals("Semanal")) return 7;
            return 1;
        }
    }
}
