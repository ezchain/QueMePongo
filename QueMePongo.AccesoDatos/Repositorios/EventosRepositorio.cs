using QueMePongo.AccesoDatos.Data;
using QueMePongo.AccesoDatos.Entidades;
using QueMePongo.AccesoDatos.Mapper;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QueMePongo.AccesoDatos.Repositorios
{
    public class EventosRepositorio
    {
        readonly DbContext2 _dbContext;

        public EventosRepositorio()
        {
            _dbContext = new DbContext2();
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
            catch (Exception e)
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
                Evento evento = EventoMapper.MapModel(entidad);
                return evento;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ICollection<Evento> GetEventoPorUsuario(int UsuarioId)
        {
            try
            {
                ICollection<EventoEntity> entidades = _dbContext.Eventos.Where(s => s.UsuarioId == UsuarioId).ToList();
                ICollection<Evento> eventos = new List<Evento>();
                foreach (var x in entidades)
                {
                    eventos.Add(EventoMapper.MapModel(x));
                }

                return eventos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ICollection<EventoEntity> ObtenerEventos()
        {
            return _dbContext.Eventos.ToList();

        }
        public void DeleteEvento(int EventoId)
        {
            try
            {

                _dbContext.Eventos.Remove(_dbContext.Eventos.Find(EventoId));
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
