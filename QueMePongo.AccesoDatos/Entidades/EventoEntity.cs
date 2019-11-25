using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QueMePongo.AccesoDatos.Entidades
{
    public class EventoEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventoId { get; set; }
        [Key]
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Formalidad { get; set; }
        public string Frecuencia { get; set; }
        public DateTime FechaInicio { get; set; }
    }
}
