using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Interfaces.Validacion;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Negocio.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        readonly IGuardarropaRepositorio _guardarropaRepositorio;
        readonly IUsuarioRepositorio _usuarioRepositorio;


        public UsuarioService()
        {

        }
        public UsuarioService(IGuardarropaRepositorio guardarropaRepositorio,
            IUsuarioRepositorio usuarioRepositorio)
        {
            _guardarropaRepositorio = guardarropaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }


        #region Metodos Publicos
        public Usuario GetUsuario(int idUsuario)
        {
            return this._usuarioRepositorio.ObtenerUsuarioPorId(idUsuario);
        }

        public void AgregarGuardarropa(int idUsuario, int idGuardarropa)
        {
            Usuario usuario = GetUsuario(idUsuario);
                
            if(UsuarioTieneGuardarropa(usuario, idGuardarropa))
            {
                throw  new Exception("El Usuario ya tiene asignado el guardarropa ingresado");
            }
            else
            {
                this._usuarioRepositorio.AgregarGuardarropa(idUsuario, idGuardarropa);
            }    

        }

        public void AgregarPrenda(int idUsuario,int idGuardarropa,Prenda prenda)
        {
            Usuario usuario = GetUsuario(idUsuario);
            if (UsuarioTieneGuardarropa(usuario, idGuardarropa))
            {
                Guardarropa guardarropa = this._guardarropaRepositorio.ObtenerGuardarropaPorId(idGuardarropa);
                if (usuario.TipoUsuario.Equals(1))
                {
                    if (guardarropa.Prendas.Count + 1 <= guardarropa.PrendasMaximas)
                    {
                        this._guardarropaRepositorio.AgregarPrenda(idGuardarropa,prenda);
                    }
                    else
                    {
                        throw new Exception("El guardarropa esta lleno");
                    }
                }
                else
                {
                    this._guardarropaRepositorio.AgregarPrenda(idGuardarropa,prenda);
                }
            }
            else
            {
                throw new Exception("El usuario no tiene el guardarropa ingresado");

            }


        }
        #endregion

        #region Metodos Privados
        private bool UsuarioTieneGuardarropa(Usuario usuario,int idGuardarropa)
        {
            foreach(var guardarropa in usuario.Guardarropas)
            {
                return idGuardarropa == guardarropa.GuardarropaId;
            }
            return false;
        }
        #endregion
    }
}
