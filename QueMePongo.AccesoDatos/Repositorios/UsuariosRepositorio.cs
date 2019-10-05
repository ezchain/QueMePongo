using Microsoft.EntityFrameworkCore;
using QueMePongo.AccesoDatos.Data;
using QueMePongo.AccesoDatos.Entidades;
using QueMePongo.AccesoDatos.Entities;
using QueMePongo.AccesoDatos.Mapper;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.AccesoDatos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        readonly QueMePongoDbContext _dbContext;

        public UsuarioRepositorio(QueMePongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Métodos Públicos

        public Usuario CrearUsuario(Usuario Usuario)
        {
            UsuarioEntity entidad =  UsuarioMapper.MapEntity(Usuario);
            SensibilidadLocalEntity sensibilidadEntidad = SensibilidadLocalMapper.MapEntity(Usuario.Sensibilidad);
            sensibilidadEntidad.UsuarioId = Usuario.UsuarioId;
            _dbContext.Usuarios.Add(entidad);
            _dbContext.SaveChanges();

            return Usuario;
        }

        public void UpdateUsuario(Usuario Usuario)
        {
            //_dbContext.Entry(Usuario).State = EntityState.Modified;

            //var guardarropas = _dbContext.Guardarropas
            //    .Where(p => p.Usuarios.Contains(Usuario.UsuarioId));

            //foreach (var guardarropa in guardarropas)
            //{
            //    if (!Usuario.Guardarropas.Any(p => p.GuardarropaId == guardarropa.GuardarropaId))
            //        _dbContext.Entry(guardarropa).State = EntityState.Deleted;
            //}

            UsuarioEntity entidad = UsuarioMapper.MapEntity(Usuario);
            SensibilidadLocalEntity sensibilidadEntidad = SensibilidadLocalMapper.MapEntity(Usuario.Sensibilidad);
            sensibilidadEntidad.UsuarioId = Usuario.UsuarioId;
            _dbContext.Usuarios.Update(entidad);
            _dbContext.SaveChanges();
        }

        public void EliminarUsuario(int id)
        {
            var Usuario = _dbContext.Usuarios.Find(id);

            if (Usuario == null)
                throw new KeyNotFoundException();

            _dbContext.Usuarios.Remove(Usuario);
            _dbContext.SaveChanges();
        }

        public Usuario ObtenerUsuario(int usuarioId)
        {
            //return _dbContext.Usuarios
            //    .Include(u => u.Guardarropas)
            //    .FirstOrDefault(u => u.UsuarioId == id);
            UsuarioEntity entidad = _dbContext.Usuarios.Find(usuarioId);
            Usuario usuario = UsuarioMapper.MapModel(entidad);
            SensibilidadLocalEntity sensibilidad = _dbContext.SensibilidadLocal.Find(usuarioId);
            usuario.CambiarSensibilidadLocal(SensibilidadLocalMapper.MapModel(sensibilidad));

            return usuario;
        }

        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            //  return _dbContext.Usuarios.Include(u => u.Guardarropas);
            return null;
        }

        public void AgregarGuardarropa(int idUsuario, int idGuardarropa)
        {

        }

        #endregion
    }
}
