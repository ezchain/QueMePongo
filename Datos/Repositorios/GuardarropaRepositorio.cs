using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos.Repositorios
{
    public class GuardarropaRepositorio : IGuardarropaRepositorio
    {
        readonly QueMePongoDbContext _dbContext;

        public GuardarropaRepositorio(QueMePongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Guardarropa> ObtenerGuardarropas()
        {
            return _dbContext.Guardarropas.ToList();
        }

    }
}
