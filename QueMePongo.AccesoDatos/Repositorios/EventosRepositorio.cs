using QueMePongo.AccesoDatos.Data;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.AccesoDatos.Repositorios
{
    public class EventosRepositorio
    {
        readonly QueMePongoDbContext _dbContext;

        public EventosRepositorio(QueMePongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Evento CrearEvento(Evento evento)
        {
            _dbContext.Eventos.Add(evento);
            _dbContext.SaveChanges();

            return evento;
        }
    }
}
