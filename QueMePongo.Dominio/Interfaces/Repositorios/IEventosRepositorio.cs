using QueMePongo.Dominio.Models;

namespace QueMePongo.Dominio.Interfaces.Repositorios
{
    public interface IEventosRepositorio
    {
        Evento GuardarEvento(Evento evento);
    }
}
