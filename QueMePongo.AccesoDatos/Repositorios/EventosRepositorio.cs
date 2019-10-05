using QueMePongo.AccesoDatos.Data;
using QueMePongo.AccesoDatos.Entidades;
using QueMePongo.AccesoDatos.Mapper;
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
            try
            {
                EventoEntity entidad = EventoMapper.MapEntity(evento);
                _dbContext.Eventos.Add(entidad);

                _dbContext.SaveChanges();

                return evento;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void UpdateEvento(Evento evento)
        {
            try
            {
                EventoEntity entidad = EventoMapper.MapEntity(evento);
                _dbContext.Eventos.Update(entidad);

                _dbContext.SaveChanges();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Evento GetEvento(int EventoId)
        {
            try
            {
                EventoEntity entidad = _dbContext.Eventos.Find(EventoId);
                return EventoMapper.MapModel(entidad);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        //public void DeleteEvento(int EventoId)
        //{
        //    try
        //    {
        //        _dbContext.Remove(EventoId);
        //    }catch(Exception e)
        //    {

        //    }
        
    }
}
