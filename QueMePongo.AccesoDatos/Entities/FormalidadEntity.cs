﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QueMePongo.AccesoDatos.Entities
{
    public class FormalidadEntity
    {
        [Key]
        public int FormalidadId { get; set; }
        public string Tipo { get; set; }
    }
}
