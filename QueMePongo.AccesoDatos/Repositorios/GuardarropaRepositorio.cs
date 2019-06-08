using Microsoft.EntityFrameworkCore;
using QueMePongo.AccesoDatos.Data;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.AccesoDatos.Repositorios
{
    public class GuardarropaRepositorio : IGuardarropaRepositorio
    {
        readonly QueMePongoDbContext _dbContext;

        public GuardarropaRepositorio(QueMePongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Métodos Públicos

        public Guardarropa CrearGuardarropa(Guardarropa guardarropa)
        {
            _dbContext.Guardarropas.Add(guardarropa);
            _dbContext.SaveChanges();

            return guardarropa;
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
            return _dbContext.Guardarropas
                .Include(gr => gr.Prendas)
                .FirstOrDefault(gr => gr.GuardarropaId == id);
        }

        public IEnumerable<Guardarropa> ObtenerGuardarropas()
        {
            return _dbContext.Guardarropas.Include(gr => gr.Prendas);
        }

        public void AgregarPrenda(int idGuardarropa,Prenda prenda)
        {

        }

        #endregion
    }
}
