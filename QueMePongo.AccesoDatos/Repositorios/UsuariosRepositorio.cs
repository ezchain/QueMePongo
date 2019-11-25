using Microsoft.EntityFrameworkCore;
using QueMePongo.AccesoDatos.Data;
using QueMePongo.AccesoDatos.Entidades;
using QueMePongo.AccesoDatos.Entities;
using QueMePongo.AccesoDatos.Mapper;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.AccesoDatos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        readonly DbContext2 _dbContext;

        public UsuarioRepositorio()
        {
            _dbContext = new DbContext2();
        }

        #region Métodos Públicos

        public Usuario CrearUsuario(Usuario Usuario)
        {
            UsuarioEntity entidad =  UsuarioMapper.MapEntity(Usuario);
            SensibilidadLocalEntity sensibilidadEntidad = SensibilidadLocalMapper.MapEntity(Usuario.Sensibilidad);
            sensibilidadEntidad.UsuarioId = Usuario.UsuarioId;
            _dbContext.Usuarios.Add(entidad);
            _dbContext.SensibilidadLocal.Add(sensibilidadEntidad);
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
            try
            {
                var Usuario = _dbContext.Usuarios.Find(id);
                var sensibilidad = _dbContext.SensibilidadLocal.Find(id);
                if (Usuario == null)
                    throw new KeyNotFoundException();

                _dbContext.Usuarios.Remove(Usuario);
                _dbContext.SensibilidadLocal.Remove(sensibilidad);
                _dbContext.SaveChanges();
            }catch(Exception e)
            {
                throw e;
            }
            
        }

        public Usuario ObtenerUsuario(int usuarioId)
        {
            //return _dbContext.Usuarios
            //    .Include(u => u.Guardarropas)
            //    .FirstOrDefault(u => u.UsuarioId == id);
            UsuarioEntity entidad = _dbContext.Usuarios.FirstOrDefault(s => s.UsuarioId == usuarioId);
            GuardarropaRepositorio repo = new GuardarropaRepositorio(); 
            Usuario usuario = UsuarioMapper.MapModel(entidad);
            usuario.Guardarropas = new List<Guardarropa>();
            usuario.Guardarropas = repo.ObtenerGuardarropasUsuario(usuarioId);
            SensibilidadLocalEntity sensibilidad = _dbContext.SensibilidadLocal.Find(usuarioId);
            usuario.CambiarSensibilidadLocal(SensibilidadLocalMapper.MapModel(sensibilidad));

            return usuario;
        }


        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            var usuarios = _dbContext.Usuarios.ToList();
            var list = new List<Usuario>();
            foreach(var usuario in usuarios)
            {
                list.Add(UsuarioMapper.MapModel(usuario));
            }
            return list;
        }

       

        #endregion
    }
}
