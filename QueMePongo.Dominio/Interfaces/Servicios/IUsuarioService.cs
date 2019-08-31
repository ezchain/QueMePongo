using QueMePongo.Dominio.Models;

namespace QueMePongo.Dominio.Interfaces.Servicios
{
    public interface IUsuarioService
    {
        void AgregarGuardarropa(int idUsuario, int idGuardarropa);
        void AgregarPrenda(int idUsuario, int idGuardarropa, Prenda prenda);
        Usuario GetUsuario(int idUsuario);
        void GuardarUsuario(Usuario usuario);
    }
}
