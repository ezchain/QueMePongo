using Microsoft.EntityFrameworkCore;
using QueMePongo.AccesoDatos.Data;
using QueMePongo.AccesoDatos.Entities;
using QueMePongo.AccesoDatos.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.AccesoDatos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly QueMePongoDbContext _dbContext;

        public UsuarioRepositorio(QueMePongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Métodos Públicos

        public UsuarioEntity CrearUsuario(UsuarioEntity Usuario)
        {
            _dbContext.Usuarios.Add(Usuario);
            _dbContext.SaveChanges();

            return Usuario;
        }

        public void EditarUsuario(UsuarioEntity Usuario)
        {
            _dbContext.Entry(Usuario).State = EntityState.Modified;

            var guardarropas = _dbContext.Guardarropas
                .Where(p => p.Usuarios.Contains(Usuario.UsuarioId));

            foreach (var guardarropa in guardarropas)
            {
                if (!Usuario.Guardarropas.Any(p => p.GuardarropaId == guardarropa.GuardarropaId))
                {
                    _dbContext.Entry(guardarropa).State = EntityState.Deleted;
                }
            }

            _dbContext.SaveChanges();
        }

        public void EliminarUsuario(int id)
        {
            var Usuario = _dbContext.Usuarios.Find(id);

            if (Usuario == null)
            {
                throw new KeyNotFoundException();
            }

            _dbContext.Usuarios.Remove(Usuario);
            _dbContext.SaveChanges();
        }

        public UsuarioEntity ObtenerUsuarioPorId(int id)
        {
            return _dbContext.Usuarios
                .Include(u => u.Guardarropas)
                .FirstOrDefault(u => u.UsuarioId == id);
        }

        public IEnumerable<UsuarioEntity> ObtenerUsuarios()
        {
            return _dbContext.Usuarios.Include(u => u.Guardarropas);
        }

        public void AgregarGuardarropa(int idUsuario, int idGuardarropa)
        {

        }

        #endregion
    }
}
