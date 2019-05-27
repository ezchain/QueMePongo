using QueMePongo.AccesoDatos.Data;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.AccesoDatos.Repositorios
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
