using QueMePongo.AccesoDatos.Data;
using QueMePongo.AccesoDatos.Entities;
using QueMePongo.AccesoDatos.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.AccesoDatos.Repositorios
{
    public class PrendasRepositorio : IPrendasRepositorio
    {
        private readonly QueMePongoDbContext dbContext;

        public PrendasRepositorio(QueMePongoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddPrenda(PrendaEntity prenda)
        {
            dbContext.Add(prenda);
            dbContext.SaveChanges();
        }

        public void DeletePrenda(int id)
        {
            var prenda = dbContext.Prendas.Find(id);
            if (prenda == null)
            {
                throw new ArgumentException("La prenda no existe");
            }

            dbContext.Remove(prenda);
            dbContext.SaveChanges();

        }

        public PrendaEntity GetPrenda(int id)
        {
            return dbContext.Prendas.FirstOrDefault(pr => pr.PrendaId == id);
        }

        public IEnumerable<PrendaEntity> GetPrendas()
        {
            return dbContext.Prendas.ToList();
        }

        public void UpdatePrenda(PrendaEntity prenda)
        {
            dbContext.Update(prenda);
            dbContext.SaveChanges();
        }
    }
}
