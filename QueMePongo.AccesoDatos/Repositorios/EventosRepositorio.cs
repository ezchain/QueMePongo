using QueMePongo.AccesoDatos.Data;
using QueMePongo.AccesoDatos.Entities;
using QueMePongo.AccesoDatos.Repositorios.Interfaces;

namespace QueMePongo.AccesoDatos.Repositorios
{
    public class EventosRepositorio : IEventosRepositorio
    {
        private readonly QueMePongoDbContext _dbContext;

        public EventosRepositorio(QueMePongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EventoEntity CrearEvento(EventoEntity evento)
        {
            _dbContext.Eventos.Add(evento);
            _dbContext.SaveChanges();

            return evento;
        }
    }
}
