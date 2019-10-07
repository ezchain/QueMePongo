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


            return new UsuarioEntity()
            {
                UsuarioId = usuario.UsuarioId,
                Username = usuario.Username,
                Password = usuario.Password,
                Mail = usuario.Mail,
               
                Sensibilidad = usuario.Sensibilidad.GetNombre(),
                TipoUsuario = usuario.TipoUsuario.GetTipo()

            };
        }
        public static Usuario MapModel(UsuarioEntity entidad)
        {

            return new Usuario()
            {
                UsuarioId = entidad.UsuarioId,
                Mail = entidad.Mail,
                Username = entidad.Username,
                Password = entidad.Password,
                TipoUsuario = ObtenerEnumTipoUsuario(entidad.TipoUsuario),
                Sensibilidad = ObtenerSensibilidad(entidad.Sensibilidad)
            };
        }
        private static ITipoUsuario ObtenerEnumTipoUsuario(string tipoUsuario)
        {
            if (tipoUsuario.Equals("Premium")) return new Premium();
            return new Gratuito();
        }

        private static ISensibilidad ObtenerSensibilidad(string sensibilidad)
        {
            if (sensibilidad.Equals("Friolento")) return new Friolento();
            if (sensibilidad.Equals("Acalorado")) return new Acalorado();
            if (sensibilidad.Equals("MuyFriolento")) return new MuyFriolento();
            if (sensibilidad.Equals("MuyAcalorado")) return new MuyAcalorado();
            return new Normal();

        }
    }
}
