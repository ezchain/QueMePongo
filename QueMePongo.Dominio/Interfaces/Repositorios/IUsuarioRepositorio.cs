using System.Collections.Generic;
using QueMePongo.Dominio.Models;

namespace QueMePongo.Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario CrearUsuario(Usuario Usuario);
        void EditarUsuario(Usuario Usuario);
        void EliminarUsuario(int id);
        Usuario ObtenerUsuarioPorId(int id);
        IList<Usuario> ObtenerUsuarios();
    }
}