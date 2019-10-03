using QueMePongo.AccesoDatos.Entidades;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using QueMePongo.Dominio.TipoUsuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.AccesoDatos.Mapper
{
   public static class UsuarioMapper
    {
        public static UsuarioEntity MapEntity(Usuario usuario)
        {
            ICollection<GuardarropaEntity> guardarropa = new List<GuardarropaEntity>();
            foreach(var x in usuario.Guardarropas)
            {
                guardarropa.Add(GuardarropaMapper.MapEntity(x));
            }

            return new UsuarioEntity()
            {
                UsuarioId = usuario.UsuarioId,
                Username = usuario.Username,
                Password = usuario.Password,
                Mail = usuario.Mail,
                Guardarropas = guardarropa,
                Sensibilidad = usuario.Sensibilidad.GetNombre(),
                TipoUsuario = usuario.TipoUsuario.GetTipo(),
                SensibilidadLocal
                
            };
        }
        public static Usuario MapModel(UsuarioEntity entidad)
        {
            ICollection<Guardarropa> guardarropas = new List<Guardarropa>();
            foreach(var x in entidad.Guardarropas)
            {
                guardarropas.Add(GuardarropaMapper.MapModel(x));
            }
            return new Usuario()
            {
                UsuarioId = entidad.UsuarioId,
                Mail = entidad.Mail,
                Username = entidad.Username,
                Password = entidad.Password,
                Guardarropas = guardarropas,
                TipoUsuario = ObtenerEnumTipoUsuario(entidad.TipoUsuario),
                Sensibilidad


            };
        }
        private static ITipoUsuario  ObtenerEnumTipoUsuario(string tipoUsuario)
        {
            if (tipoUsuario.Equals("Premium")) return new Premium();
            return new Gratuito();
        }
    }
}
