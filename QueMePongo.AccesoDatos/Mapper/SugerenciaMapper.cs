using QueMePongo.AccesoDatos.Entidades;
using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.AccesoDatos.Mapper
{
   public static class SugerenciaMapper
    {
        public static SugerenciaEntity MapEntity(Sugerencia sugerencia)
        {
            ICollection<PrendaEntity> prendas = new List<PrendaEntity>();
            foreach(var x in sugerencia.Atuendo.Prendas)
            {
                prendas.Add(PrendaMapper.MapEntity(x));
            }

            return new SugerenciaEntity()
            {
                UsuarioId = sugerencia.UsuarioId,
                SugerenciaId = sugerencia.SugerenciaId,
                CalorTotal = sugerencia.CalorTotal,
                Aceptada = sugerencia.Aceptada,
                Atuendo = prendas
            };
        }
        public static Sugerencia MapModel(SugerenciaEntity entidad)
        {
            Atuendo atuendo = new Atuendo();
            foreach(var x in entidad.Atuendo)
            {
               atuendo.Prendas.Add
            }
            return new Sugerencia(atuendo)
            {
                SugerenciaId = entidad.SugerenciaId,
                Aceptada = entidad.Aceptada,
                UsuarioId = entidad.UsuarioId
            };
        }
    }
}
