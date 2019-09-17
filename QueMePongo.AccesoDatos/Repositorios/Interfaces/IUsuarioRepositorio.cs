using QueMePongo.AccesoDatos.Entities;
using System.Collections.Generic;


namespace QueMePongo.AccesoDatos.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        UsuarioEntity CrearUsuario(UsuarioEntity Usuario);
        void EditarUsuario(UsuarioEntity Usuario);
        void EliminarUsuario(int id);
        UsuarioEntity ObtenerUsuarioPorId(int id);
        IEnumerable<UsuarioEntity> ObtenerUsuarios();
        void AgregarGuardarropa(int idUsuario, int idGuardarropa);
    }
}