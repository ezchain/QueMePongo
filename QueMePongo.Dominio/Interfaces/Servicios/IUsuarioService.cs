using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Interfaces.Servicios
{
   public interface IUsuarioService
    {
        Usuario GetUsuario(int idUsuario);
        void AgregarGuardarropa(int idUsuario, int idGuardarropa);
        void AgregarPrenda(int idUsuario, int idGuardarropa, Prenda prenda);
    }
}
