using Microsoft.EntityFrameworkCore;
using QueMePongo.AccesoDatos.Data;
using QueMePongo.AccesoDatos.Entidades;
using QueMePongo.AccesoDatos.Mapper;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.AccesoDatos.Repositorios
{
    public class GuardarropaRepositorio : IGuardarropaRepositorio
    {
        readonly DbContext2 _dbContext;

        public GuardarropaRepositorio()
        {
            _dbContext = new DbContext2();
        }

        #region Métodos Públicos

        public Guardarropa CrearGuardarropa(Guardarropa guardarropa)
        {
            try
            {
                GuardarropaEntity entidad = GuardarropaMapper.MapEntity(guardarropa);
                _dbContext.Guardarropas.Add(entidad);
                _dbContext.SaveChanges();
                PrendasRepositorio repo = new PrendasRepositorio();
                foreach(var x in guardarropa.Prendas)
                {
                    repo.AddPrenda(x);
                }
                foreach(var x in guardarropa.Usuarios)
                {
                    AgregarGuardarropa(x, guardarropa.GuardarropaId);
                }
                return guardarropa;
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public void AgregarGuardarropa(int idUsuario, int idGuardarropa)
        {
            try
            {
                _dbContext.GuardarropasUsuarios.Add(new GuardarropasUsuariosEntity() { IDGuardarropa = idGuardarropa, UsuarioId = idUsuario });
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void EditarGuardarropa(Guardarropa guardarropa)
        {
            _dbContext.Entry(guardarropa).State = EntityState.Modified;

            var prendas = _dbContext.Prendas
                .Where(p => p.GuardarropaId == guardarropa.GuardarropaId);

            foreach (var prenda in prendas)
            {
                if (!guardarropa.Prendas.Any(p => p.PrendaId == prenda.PrendaId))
                    _dbContext.Entry(prenda).State = EntityState.Deleted;
            }

            _dbContext.SaveChanges();
        }

        public void EliminarGuardarropa(int id)
        {
            var guardarropa = _dbContext.Guardarropas.Find(id);

            if (guardarropa == null)
                throw new KeyNotFoundException();

            _dbContext.Guardarropas.Remove(guardarropa);
            _dbContext.SaveChanges();
        }

        public Guardarropa ObtenerGuardarropaPorId(int id)
        {
            try
            {
                GuardarropaEntity guardarropa = _dbContext.Guardarropas.Find(id);
                PrendasRepositorio repo = new PrendasRepositorio();
                ICollection<Prenda> prendas = repo.GetPrendasGuardarropa(id);
                Guardarropa model = GuardarropaMapper.MapModel(guardarropa);
                model.Prendas = prendas;
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public IEnumerable<Guardarropa> ObtenerGuardarropas()
        {
            // return _dbContext.Guardarropas.Include(gr => gr.Prendas);
            return null;
        }

        public void AgregarPrenda(int idGuardarropa, Prenda prenda)
        {

        }
        public ICollection<Guardarropa> ObtenerGuardarropasUsuario(int UsuarioId)
        {
            try
            {
                ICollection<GuardarropasUsuariosEntity> entidades = _dbContext.GuardarropasUsuarios.Where(s => s.UsuarioId == UsuarioId).ToList();
                ICollection<Guardarropa> guardarropas = new List<Guardarropa>();
                foreach (var x in entidades)
                {
                    guardarropas.Add(ObtenerGuardarropaPorId(x.IDGuardarropa));
                }
                return guardarropas;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
