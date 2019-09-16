﻿using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueMePongo.Dominio.Models
{
    public class SensibilidadLocalAcalorado : ISensibilidadLocal
    {
        PosicionPrenda Posicion { get; set; }
        public SensibilidadLocalAcalorado(PosicionPrenda posicion)
        {
            Posicion = posicion;
        }
        public IEnumerable<Atuendo> AplicarSensibilidadLocal(IEnumerable<Atuendo> atuendos)
        {
            return atuendos.Where(p => !Helper.AtuendoTienePosicion(p, Posicion.GetAttribute<Posicion>().PosicionPrenda));
        }
    }
}
