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

                if (usuario.TipoUsuario.Equals(TipoUsuario.Gratuito))
                {
                    if (guardarropa.Prendas.Count < guardarropa.PrendasMaximas)
                    {
                        _guardarropaRepositorio.AgregarPrenda(idGuardarropa, prenda);
                    }
                    else
                    {
                        throw new InvalidOperationException("El guardarropa esta lleno");
                    }
                }
                else
                {
                    _guardarropaRepositorio.AgregarPrenda(idGuardarropa, prenda);
                }
            }
            else
            {
                throw new InvalidOperationException("El usuario no tiene el guardarropa ingresado");
            }
        }

        #endregion

        #region Metodos Privados

        private bool UsuarioTieneGuardarropa(Usuario usuario, int idGuardarropa)
        {
            return usuario.Guardarropas
                .Select(gr => gr.GuardarropaId)
                .Contains(idGuardarropa);
        }

        private Usuario GetUsuario(int idUsuario)
        {
            return _usuarioRepositorio.ObtenerUsuarioPorId(idUsuario);
        }

        #endregion
    }
}
