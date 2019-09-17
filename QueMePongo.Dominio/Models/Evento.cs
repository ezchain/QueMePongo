using System;

namespace QueMePongo.Dominio.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public Ubicacion Ubicacion { get; set; }
        public int Formalidad { get; set; }
        public Frecuencia Frecuencia { get; set; }
        public DateTime FechaInicio { get; set; }

        public Evento(Enums.FrecuenciaEvento frecuencia, Action<Evento> getSugerencias)
        {
            Frecuencia = new Frecuencia(
                frecuencia.GetAttribute<IntervaloFrecuencia>().Intervalo,
                getSugerencias,
                this);
        }

        public bool Disponible()
        {
            return Frecuencia.TiempoTranscurrido();
        }
    }
}
