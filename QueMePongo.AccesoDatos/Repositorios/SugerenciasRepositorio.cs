using QueMePongo.AccesoDatos.Data;
using QueMePongo.AccesoDatos.Entidades;
using QueMePongo.AccesoDatos.Mapper;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QueMePongo.AccesoDatos.Repositorios
{
    public class SugerenciasRepositorio
    {
        public void CrearSugerencia(Sugerencia sugerencia)
        {
            try
            {
                using (var context = new DbContext2())
                {
                    SugerenciaEntity entidad = SugerenciaMapper.MapEntity(sugerencia);
                    context.Sugerencias.Add(entidad);
                    foreach (var x in sugerencia.Atuendo.Prendas)
                    {
                        context.PrendasSugerencia.Add(new PrendasSugerenciaEntity() { SugerenciaId = sugerencia.SugerenciaId, PrendaId = x.PrendaId });
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Sugerencia ObtenerSugerencia(int SugerenciaId)
        {
            try
            {
                using (var context = new DbContext2())
                {
                    SugerenciaEntity entidad = context.Sugerencias.Find(SugerenciaId);
                    ICollection<PrendasSugerenciaEntity> prendas = context.PrendasSugerencia.Where(s => s.SugerenciaId == SugerenciaId).ToList();
                    Sugerencia sugerencia = SugerenciaMapper.MapModel(entidad);
                    PrendasRepositorio repo = new PrendasRepositorio();
                    foreach (var x in prendas)
                    {
                        sugerencia.Atuendo.Prendas.Add(repo.GetPrenda(x.PrendaId));
                    }
                    return sugerencia;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
