﻿using QueMePongo.AccesoDatos.Entities;
using QueMePongo.AccesoDatos.Mapper;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.AccesoDatos.Mapper
{
    public static class SensibilidadLocalMapper
    {
        public static SensibilidadLocalEntity MapEntity(ISensibilidad sensibilidad)
        {
            SensibilidadLocalEntity entidad = new SensibilidadLocalEntity();
            IEnumerable<string> sensibilidades = sensibilidad.ObtenerSensibilidadesLocales();
           foreach (var x in sensibilidades)
            {
                if (x.Contains("Acalorado") && x.Contains("Cabeza")) entidad.Cabeza = "Acalorado";
                else if (x.Contains("Friolento") && x.Contains("Cabeza")) entidad.Cabeza = "Friolento";
                else entidad.Cabeza = "";

                if (x.Contains("Acalorado") && x.Contains("Cuello")) entidad.Cuello = "Acalorado";
                else if (x.Contains("Friolento") && x.Contains("Cuello")) entidad.Cuello = "Friolento";
                else entidad.Cuello = "";

                if (x.Contains("Acalorado") && x.Contains("Manos")) entidad.Manos = "Acalorado";
                else if (x.Contains("Friolento") && x.Contains("Manos")) entidad.Manos = "Friolento";
                else entidad.Manos = "";
            }
            return entidad;
        }

        public static IList<ISensibilidadLocal> MapModel(SensibilidadLocalEntity entidad)
        {
            IList<ISensibilidadLocal> sensibilidades = new List<ISensibilidadLocal>();
            if (entidad == null)
            {
                sensibilidades.Add(new NormalLocal());
                return sensibilidades;
            }
           
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
