using QueMePongo.AccesoDatos.Data;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.AccesoDatos.Repositorios
{
    public class PrendasRepositorio : IPrendasRepositorio
    {
        readonly QueMePongoDbContext _dbContext;

        public PrendasRepositorio(QueMePongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Prenda> ObtenerPrendas()
        {
            var prendas = _dbContext.Prendas.ToList();
            return prendas;
        }
    }
}
