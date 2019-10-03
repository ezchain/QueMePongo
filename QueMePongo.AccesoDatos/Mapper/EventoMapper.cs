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

        public static Evento MapModel(EventoEntity)
        {
            return new Evento()
            {

            };
        }
        private static string ObtenerFormalidad(Formalidad formalidad)
        {
            if (formalidad == Formalidad.Normal) return "Normal";
            if (formalidad == Formalidad.Formal) return "Formal";
            if (formalidad == Formalidad.Distendido) return "Distendido";
            return String.Empty;
        }
    }
}
