﻿using Combinatorics.Collections;
using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Interfaces.Validacion;
using QueMePongo.Dominio.Models;
using QueMePongo.Negocio.Validaciones;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.Negocio.Servicios
{
    public class AtuendosService : IAtuendosService
    {
        readonly IGuardarropaRepositorio _guardarropaRepositorio;
        readonly IUsuarioRepositorio _usuarioRepositorio;
        readonly IEstrategiaValidacion _estrategiaValidacion;

        public AtuendosService()
        {

        }
        public AtuendosService(IGuardarropaRepositorio guardarropaRepositorio,
            IUsuarioRepositorio usuarioRepositorio,
            IEstrategiaValidacion estrategiaValidacion)
        {
            _guardarropaRepositorio = guardarropaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _estrategiaValidacion = estrategiaValidacion;
        }

        public IEnumerable<Atuendo> GenerarAtuendosPorGuardarropa(int guardarropaId)
        {
            var guardarropa = _guardarropaRepositorio.ObtenerGuardarropaPorId(guardarropaId);
            var combinaciones = new Combinations<Prenda>(guardarropa.Prendas.ToList(), 5);

            return CrearAtuendos(combinaciones);
        }

        public IEnumerable<Atuendo> GenerarAtuendosPorUsuario(int usuarioId)
        {
            var usuario = _usuarioRepositorio.ObtenerUsuarioPorId(usuarioId);
            IEnumerable<Atuendo> prendas = new List<Atuendo>();
            foreach (var guardarropa in usuario.Guardarropas)
            {
                prendas.Concat(GenerarAtuendosPorGuardarropa(guardarropa.GuardarropaId));
            }
            return prendas;
        }

        private IEnumerable<Atuendo> CrearAtuendos(Combinations<Prenda> combinaciones)
        {
            var combinacionesCorrectas = new List<List<Prenda>>();

            //_estrategiaValidacion.SetEstrategia(
            //    new ValidadorAtuendo(combinaciones, combinacionesCorrectas));

         
            //    _estrategiaValidacion.RealizarValidacion(combinacion);

            foreach(var combinacion in combinaciones)
            {
                var combinacionList = combinacion.ToList(); 
                if (ValidadorAtuendo.Validar(combinacionList))
                {
                    combinacionesCorrectas.Add(combinacionList);
                }
            }
            return combinacionesCorrectas.Select(c => new Atuendo { Prendas = c });
        }

    }
}
