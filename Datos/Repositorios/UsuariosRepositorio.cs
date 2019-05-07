using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos.Repositorios
{
    public class UsuariosRepositorio
    {
        readonly QueMePongoDbContext _dbContext;

        public UsuariosRepositorio(QueMePongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Guardarropa> ObtenerGuardarropas()
        {
            var guardarropas = _dbContext.Guardarropas.ToList();
         
            return guardarropas;
        }


    }
}
