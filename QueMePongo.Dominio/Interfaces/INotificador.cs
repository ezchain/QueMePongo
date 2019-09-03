using QueMePongo.Dominio.Models;

namespace QueMePongo.Dominio.Interfaces
{
    public interface INotificador
    {
        void NotificarSugerencias(Usuario usuario, Evento evento);

        void NotificarAlertaMeterologica(int idUsuario, string alerta);
    }
}
