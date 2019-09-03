﻿using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueMePongo.Dominio.Models
{
    #region Sensibilidad
    public class Normal : ISensibilidad
    {
        readonly IList<ISensibilidadLocal> _SensibilidadLocal;

        public Normal()
        {
            _SensibilidadLocal = new List<ISensibilidadLocal>();
            _SensibilidadLocal.Add(new NormalLocal());
        }
        public Normal(IList<ISensibilidadLocal> sensibilidadLocal)
        {
            _SensibilidadLocal = sensibilidadLocal;
        }

        public int ObtenerSensibilidadGlobal(int capas)
        {
            return capas;
        }
        public IEnumerable<Atuendo> SensibilidadLocal(IEnumerable<Atuendo> atuendos)
        {
            IEnumerable<Atuendo> Atuendos = new List<Atuendo>();
            foreach (var sensibilidad in _SensibilidadLocal)
            {
                atuendos = sensibilidad.AplicarSensibilidadLocal(atuendos);
                Atuendos = atuendos;
            }
            return Atuendos;
        }

    }
    public class Friolento : ISensibilidad
    {
        readonly IList<ISensibilidadLocal> _SensibilidadLocal;

        public Friolento()
        {
            _SensibilidadLocal = new List<ISensibilidadLocal>();
            _SensibilidadLocal.Add(new NormalLocal());
        }
        public Friolento(IList<ISensibilidadLocal> sensibilidadLocal)
        {
            _SensibilidadLocal = sensibilidadLocal;
        }
        public int ObtenerSensibilidadGlobal(int capas)
        {
            return 2;
        }
        public IEnumerable<Atuendo> SensibilidadLocal(IEnumerable<Atuendo> atuendos)
        {
            IEnumerable<Atuendo> Atuendos = new List<Atuendo>();
            foreach (var sensibilidad in _SensibilidadLocal)
            {
                atuendos = sensibilidad.AplicarSensibilidadLocal(atuendos);
                Atuendos = atuendos;
            }
            return Atuendos;
        }
    }
    public class Acalorado : ISensibilidad
    {
        readonly IList<ISensibilidadLocal> _SensibilidadLocal;

        public Acalorado()
        {
            _SensibilidadLocal = new List<ISensibilidadLocal>();
            _SensibilidadLocal.Add(new NormalLocal());
        }
        public Acalorado(IList<ISensibilidadLocal> sensibilidadLocal)
        {
            _SensibilidadLocal = sensibilidadLocal;
        }
        public int ObtenerSensibilidadGlobal(int capas)
        {
            if (capas > 1) return capas - 1;
            else return capas;
        }
        public IEnumerable<Atuendo> SensibilidadLocal(IEnumerable<Atuendo> atuendos)
        {
            IEnumerable<Atuendo> Atuendos = new List<Atuendo>();
            foreach (var sensibilidad in _SensibilidadLocal)
            {
                atuendos = sensibilidad.AplicarSensibilidadLocal(atuendos);
                Atuendos = atuendos;
            }
            return Atuendos;
        }
    }

    public class MuyFriolento : ISensibilidad
    {
        readonly IList<ISensibilidadLocal> _SensibilidadLocal;

        public MuyFriolento()
        {
            _SensibilidadLocal = new List<ISensibilidadLocal>();
            _SensibilidadLocal.Add(new NormalLocal());
        }
        public MuyFriolento(IList<ISensibilidadLocal> sensibilidadLocal)
        {
            _SensibilidadLocal = sensibilidadLocal;
        }
        public int ObtenerSensibilidadGlobal(int capas)
        {
            return 3;
        }
        public IEnumerable<Atuendo> SensibilidadLocal(IEnumerable<Atuendo> atuendos)
        {
            IEnumerable<Atuendo> Atuendos = new List<Atuendo>();
            foreach (var sensibilidad in _SensibilidadLocal)
            {
                atuendos = sensibilidad.AplicarSensibilidadLocal(atuendos);
                Atuendos = atuendos;
            }
            return Atuendos;
        }

    }

    public class MuyAcalorado : ISensibilidad
    {
        readonly IList<ISensibilidadLocal> _SensibilidadLocal;

        public MuyAcalorado()
        {
            _SensibilidadLocal = new List<ISensibilidadLocal>();
            _SensibilidadLocal.Add(new NormalLocal());
        }
        public MuyAcalorado(IList<ISensibilidadLocal> sensibilidadLocal)
        {
            _SensibilidadLocal = sensibilidadLocal;
        }
        public int ObtenerSensibilidadGlobal(int capas)
        {
            return 1;
        }
        public IEnumerable<Atuendo> SensibilidadLocal(IEnumerable<Atuendo> atuendos)
        {
            IEnumerable<Atuendo> Atuendos = new List<Atuendo>();
            foreach (var sensibilidad in _SensibilidadLocal)
            {
                atuendos = sensibilidad.AplicarSensibilidadLocal(atuendos);
                Atuendos = atuendos;
            }
            return Atuendos;
        }
    }
    #endregion

    #region SensibilidadLocal

    public class AcaloradoLocal : ISensibilidadLocal
    {
        PosicionPrenda Posicion { get; set; }
        public AcaloradoLocal(PosicionPrenda posicion)
        {
            Posicion = posicion;
        }
        public IEnumerable<Atuendo> AplicarSensibilidadLocal(IEnumerable<Atuendo> atuendos)
        {
            return atuendos.Where(p => !Helper.AtuendoTienePosicion(p, Posicion.GetAttribute<Posicion>().PosicionPrenda));
        }

    }
    public class FriolentoLocal : ISensibilidadLocal
    {
        PosicionPrenda Posicion { get; set; }
        public FriolentoLocal(PosicionPrenda posicion)
        {
            Posicion = posicion;
        }
        public IEnumerable<Atuendo> AplicarSensibilidadLocal(IEnumerable<Atuendo> atuendos)
        {
            return atuendos.Where(p => Helper.AtuendoTienePosicion(p, Posicion.GetAttribute<Posicion>().PosicionPrenda));
        }

    }

    public class NormalLocal : ISensibilidadLocal
    {
        public IEnumerable<Atuendo> AplicarSensibilidadLocal(IEnumerable<Atuendo> atuendos)
        {
            return atuendos;
        }
    }
    #endregion
}




