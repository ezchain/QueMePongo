using QueMePongo.AccesoDatos.Mapper;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.AccesoDatos.Entidades
{
    public static class SensibilidadLocalMapper
    {
        
        public static IList<ISensibilidadLocal> MapModel(SensibilidadLocalEntity entidad)
        {
            IList<ISensibilidadLocal> sensibilidades = new List<ISensibilidadLocal>();
            if (entidad.Cabeza.Equals("Friolento")) sensibilidades.Add(new FriolentoLocal(PosicionPrenda.Cabeza));
            if (entidad.Cabeza.Equals("Acalorado")) sensibilidades.Add(new AcaloradoLocal(PosicionPrenda.Cabeza));
            if (entidad.Cuello.Equals("Friolento")) sensibilidades.Add(new FriolentoLocal(PosicionPrenda.Cuello));
            if (entidad.Cuello.Equals("Acalorado")) sensibilidades.Add(new AcaloradoLocal(PosicionPrenda.Cuello));
            if (entidad.Manos.Equals("Friolento")) sensibilidades.Add(new FriolentoLocal(PosicionPrenda.Manos));
            if (entidad.Manos.Equals("Acalorado")) sensibilidades.Add(new AcaloradoLocal(PosicionPrenda.Manos));

            if (sensibilidades.Count == 0) sensibilidades.Add(new NormalLocal());

            return sensibilidades;

        }

    }
}
