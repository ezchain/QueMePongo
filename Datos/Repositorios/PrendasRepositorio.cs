using Datos.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Datos.Repositorios
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
            return _dbContext.Prendas.ToList();
        }
    }
}
