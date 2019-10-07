using System.Collections.Generic;
using QueMePongo.Dominio.Models;

namespace QueMePongo.Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario CrearUsuario(Usuario Usuario);
        void UpdateUsuario(Usuario Usuario);
        void EliminarUsuario(int id);
        Usuario ObtenerUsuario(int id);
        IEnumerable<Usuario> ObtenerUsuarios();
    }
}