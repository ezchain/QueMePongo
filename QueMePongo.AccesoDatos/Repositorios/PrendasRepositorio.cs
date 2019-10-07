using QueMePongo.AccesoDatos.Data;
using QueMePongo.AccesoDatos.Entidades;
using QueMePongo.AccesoDatos.Mapper;
using QueMePongo.Dominio.Interfaces.Repositorios;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueMePongo.AccesoDatos.Repositorios
{
    public class PrendasRepositorio : IPrendasRepositorio
    {
        private readonly DbContext2 dbContext;

        public PrendasRepositorio()
        {
            this.dbContext = new DbContext2();
        }
        //public PrendasRepositorio(QueMePongoDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}

        public void AddPrenda(Prenda prenda)
        {
            try
            {
                var entidad = PrendaMapper.MapEntity(prenda);
                dbContext.Prendas.Add(entidad);
                dbContext.SaveChanges();
            }catch(Exception e)
            {
                throw e;
            }
        }

        public void DeletePrenda(int id)
        {
            try
            {
                var prenda = dbContext.Prendas.Find(id);
                if (prenda == null)
                {
                    throw new ArgumentException("La prenda no existe");
                }

                dbContext.Remove(prenda);
                dbContext.SaveChanges();
            }catch(Exception e)
            {
                throw e;
            }
            

        }

        public Prenda GetPrenda(int id)
        {
            try
            {
               var entidad = dbContext.Prendas.Find(id);
              return  PrendaMapper.MapModel(entidad);
            }catch(Exception e)
            {
                throw e;
            }
        }

        public void UpdatePrenda(Prenda prenda)
        {
            try
            {
                var entidad = PrendaMapper.MapEntity(prenda);
                dbContext.Prendas.Update(entidad);
                dbContext.SaveChanges();
            }catch(Exception e)
            {
                throw e;
            }
            
        }
        public ICollection<Prenda> GetPrendasGuardarropa(int guardarropaId)
        {
            try
            {
                ICollection<PrendaEntity> entidades = dbContext.Prendas.Where(s => s.GuardarropaId == guardarropaId).ToList();
                ICollection<Prenda> prendas = new List<Prenda>();
                foreach (var x in entidades)
                {
                    prendas.Add(PrendaMapper.MapModel(x));
                }
                return prendas;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<Prenda> GetPrendas()
        {
            //dbContext.Prendas.Select 
            return null;
        }

    }
}
