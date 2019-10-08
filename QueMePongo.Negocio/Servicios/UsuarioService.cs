using QueMePongo.AccesoDatos.Repositorios;
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


        public UsuarioService()
        {
            _guardarropaRepositorio = new GuardarropaRepositorio();
            _usuarioRepositorio = new UsuarioRepositorio();
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
                _guardarropaRepositorio.AgregarGuardarropa(idUsuario, idGuardarropa);
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

        public void CrearUsuario(Usuario usuario)
        {
            _usuarioRepositorio.CrearUsuario(usuario);
        }
       public void EliminarUsuario(int idUsuario)
        {
            _usuarioRepositorio.EliminarUsuario(idUsuario);
        }

        public void ModificarUsuario(Usuario usuario)
        {
            _usuarioRepositorio.UpdateUsuario(usuario);
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
