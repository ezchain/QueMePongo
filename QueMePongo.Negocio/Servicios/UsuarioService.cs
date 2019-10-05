using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Models;
using System;
using System.Linq;

namespace QueMePongo.Negocio.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        readonly IGuardarropaRepositorio _guardarropaRepositorio;
        readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioService(IGuardarropaRepositorio guardarropaRepositorio,
            IUsuarioRepositorio usuarioRepositorio)
        {
            _guardarropaRepositorio = guardarropaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        #region Metodos Publicos

        public void AgregarGuardarropa(int idUsuario, int idGuardarropa)
        {
            var usuario = GetUsuario(idUsuario);

            if (UsuarioTieneGuardarropa(usuario, idGuardarropa))
            {
                throw new Exception("El Usuario ya tiene asignado el guardarropa ingresado");
            }
            else
            {
                _usuarioRepositorio.AgregarGuardarropa(idUsuario, idGuardarropa);
            }
        }

        public void AgregarPrenda(int idUsuario, int idGuardarropa, Prenda prenda)
        {
            var usuario = GetUsuario(idUsuario);
            if (UsuarioTieneGuardarropa(usuario, idGuardarropa))
            {
                var guardarropa = _guardarropaRepositorio
                    .ObtenerGuardarropaPorId(idGuardarropa);

                usuario.TipoUsuario.AgregarPrenda(idGuardarropa, guardarropa, prenda, _guardarropaRepositorio);

            }
            else
            {
                throw new InvalidOperationException("El usuario no tiene el guardarropa ingresado");
            }
        }

        public Usuario GetUsuario(int idUsuario)
        {
            return _usuarioRepositorio.ObtenerUsuario(idUsuario);
        }

        public void GuardarUsuario(Usuario usuario)
        {
            //GUARDAR EN DB
        }

        #endregion

        #region Metodos Privados

        private bool UsuarioTieneGuardarropa(Usuario usuario, int idGuardarropa)
        {
            return usuario.Guardarropas
                .Select(gr => gr.GuardarropaId)
                .Contains(idGuardarropa);
        }

        #endregion
    }
}
