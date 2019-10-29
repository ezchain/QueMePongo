using QueMePongo.AccesoDatos.Entidades;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.AccesoDatos.Mapper
{
   public static class GuardarropaMapper
    {
        public static GuardarropaEntity MapEntity(Guardarropa guardarropa)
        {
            ICollection<PrendaEntity> prendas = new List<PrendaEntity>();
            foreach(var x in guardarropa.Prendas)
            {
                prendas.Add(PrendaMapper.MapEntity(x));
            }

            return new GuardarropaEntity()
            {
                GuardarropaId = guardarropa.GuardarropaId,
                PrendasMaximas = guardarropa.PrendasMaximas,
                Usuarios = guardarropa.Usuarios,
                Prendas = prendas
            };

        }
        public static Guardarropa MapModel(GuardarropaEntity entidad)
        {
            ICollection<Prenda> prendas = new List<Prenda>();
            if (entidad.Prendas != null)
            {
                foreach (var x in entidad.Prendas)
                {
                    prendas.Add(PrendaMapper.MapModel(x));
                }
            }
            
            return new Guardarropa()
            {
            GuardarropaId = entidad.GuardarropaId,
            PrendasMaximas = entidad.PrendasMaximas,
            Usuarios = entidad.Usuarios,
            Prendas = prendas
            };
        }
    }
}
