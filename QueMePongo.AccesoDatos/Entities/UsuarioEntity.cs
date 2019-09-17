using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueMePongo.AccesoDatos.Entities
{
    public class UsuarioEntity
    {
        [Key]
        [Column("UsuarioId")]
        public int UsuarioId { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }

        [ForeignKey("TipoUsuarioEntity")]
        public int TipoUsuarioId { get; set; }
        public TipoUsuarioEntity TipoUsuario { get; set; }

        //[ForeignKey("SensibilidadEntity")]
        //public int SensibilidadId { get; set; }
        //public SensibilidadEntity Sensibilidad { get; set; }

        [NotMapped]
        public ICollection<GuardarropaEntity> Guardarropas { get; set; }
    }
}
