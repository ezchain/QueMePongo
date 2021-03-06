﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QueMePongo.AccesoDatos.Entidades
{
   public class GuardarropaEntity
    {
        [Key]
        public int GuardarropaId { get; set; }
        [NotMapped]
        public IList<int> Usuarios { get; set; }
        [NotMapped]
        public ICollection<PrendaEntity> Prendas { get; set; }
        public int PrendasMaximas { get; set; }
    }
}
