﻿using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.TipoUsuario;
using System.Collections.Generic;

namespace QueMePongo.Dominio.Models
{
    public class Usuario
    {

        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public ITipoUsuario TipoUsuario { get; set; }
        public ISensibilidad Sensibilidad { get; set; }
        public ICollection<Guardarropa> Guardarropas { get; set; }

        public Usuario()
        {
            Guardarropas = new HashSet<Guardarropa>();
            TipoUsuario = new Gratuito();
            Sensibilidad = new Normal();
        }

        public void CambiarSensibilidadLocal(IList<ISensibilidadLocal> sensibilidad)
        {
            Sensibilidad.AgregarSensibilidadLocal(sensibilidad);
        }

        
    }
}
