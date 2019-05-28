using Combinatorics.Collections;
using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.Negocio.Servicios
{
    public class AtuendosService : IAtuendosService
    {
        readonly IGuardarropaRepositorio _guardarropaRepositorio;
        readonly IUsuarioRepositorio _usuarioRepositorio;

        public AtuendosService(IGuardarropaRepositorio guardarropaRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _guardarropaRepositorio = guardarropaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IEnumerable<Atuendo> GenerarAtuendosPorGuardarropa(int guardarropaId)
        {
            var guardarropa = _guardarropaRepositorio.ObtenerGuardarropaPorId(guardarropaId);
            var combinatoria = new Combinations<Prenda>(guardarropa.Prendas.ToList(), 5);

            foreach (var prendas in combinatoria)
            {
                ValidarPrendas(prendas);
                yield return new Atuendo { Prendas = prendas };
            }
        }

        public IEnumerable<Atuendo> GenerarAtuendosPorUsuario(int usuarioId)
        {
            var usuario = _usuarioRepositorio.ObtenerUsuarioPorId(usuarioId);

            var combinatoria = new Combinations<Prenda>(
                usuario.Guardarropas.SelectMany(gr => gr.Prendas).ToList(), 5);

            foreach (var prendas in combinatoria)
            {
                ValidarPrendas(prendas);
                yield return new Atuendo { Prendas = prendas };
            }
        }

        private void ValidarPrendas(IList<Prenda> prendas)
        {
            var prendaValida = prendas
                .GroupBy(p => p.Categoria).Count() == 5;

            if (!prendaValida)
                throw new Exception("Combinacion de prendas no validas");
        }
    }
}
