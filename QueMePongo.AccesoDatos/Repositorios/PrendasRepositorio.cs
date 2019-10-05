using QueMePongo.AccesoDatos.Data;
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
        private readonly QueMePongoDbContext dbContext;

        public PrendasRepositorio(QueMePongoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddPrenda(Prenda prenda)
        {
            dbContext.Add(prenda);
            dbContext.SaveChanges();
        }

        public void DeletePrenda(int id)
        {
            var prenda = dbContext.Prendas.Find(id);
            if(prenda == null)
            {
                throw new ArgumentException("La prenda no existe");
            }

            dbContext.Remove(prenda);
            dbContext.SaveChanges();

        }

        public Prenda GetPrenda(int id)
        {
            //    return dbContext.Prendas.FirstOrDefault(pr => pr.PrendaId == id);
            //}

            //public IEnumerable<Prenda> GetPrendas()
            //{
            //    return dbContext.Prendas.ToList();
            return null;
        }

        public void UpdatePrenda(Prenda prenda)
        {
            dbContext.Update(prenda);
            dbContext.SaveChanges();
        }
        public IEnumerable<Prenda> GetPrendas()
        {
            return null;
        }
    }
}
