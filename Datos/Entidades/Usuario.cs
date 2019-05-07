using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Entidades
{
    public class Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guardarropa[] Guardarropas { get; set; }


    }
}
