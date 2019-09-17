using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueMePongo.AccesoDatos.Entities
{
    public class EventoEntity
    {
        [Key]
        public int EventoId { get; set; }

        public string Nombre { get; set; }
        [ForeignKey("UsuarioEntity")]
        public int UsuarioId { get; set; }
        public UsuarioEntity Usuario { get; set; }

        [ForeignKey("UbicacionEntity")]
        [Column("Ubicacion")]
        public int UbicacionId { get; set; }
        public UbicacionEntity Ubicacion { get; set; }

        [ForeignKey("FormalidadEntity")]
        [Column("Formalidad")]
        public int FormalidadId { get; set; }
        public FormalidadEntity Formalidad { get; set; }

        [ForeignKey("FrecuenciaEventoEntity")]
        [Column("Frecuencia")]
        public int FrecuenciaEventoId { get; set; }
        public FrecuenciaEventoEntity FrecuenciaEvento { get; set; }

        public DateTime FechaInicio { get; set; }
    }
}
