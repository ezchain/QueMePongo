using Combinatorics.Collections;
using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Managers;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.Negocio.Managers
{
    public class AtuendosManager : IAtuendosManager
    {
        readonly IGuardarropaRepositorio _guardarropaRepositorio;

        public AtuendosManager(IGuardarropaRepositorio guardarropaRepositorio)
        {
            _guardarropaRepositorio = guardarropaRepositorio;
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

        private void ValidarPrendas(IList<Prenda> prendas)
        {
            var prendaValida = prendas
                .GroupBy(p => p.Categoria).Count() == 5;

            if (!prendaValida)
                throw new Exception("Combinacion de prendas no validas");
        }
    }
}
