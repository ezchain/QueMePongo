using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QueMePongo.AccesoDatos.Entidades
{
   public class SugerenciaEntity
    {
        [Key]
        public int SugerenciaId { get; set; }
        public ICollection<PrendaEntity> Atuendo { get; set; }
        public bool Aceptada { get; set; }
        public int UsuarioId { get; set; }
        public double CalorTotal { get; set; }
    }
}
