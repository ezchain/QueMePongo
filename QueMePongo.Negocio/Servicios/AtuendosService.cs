using Combinatorics.Collections;
using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Interfaces.Validacion;
using QueMePongo.Dominio.Models;
using QueMePongo.Negocio.Helpers;
using QueMePongo.Negocio.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.Negocio.Servicios
{
    public class AtuendosService : IAtuendosService
    {
        readonly IGuardarropaRepositorio _guardarropaRepositorio;
        readonly IUsuarioRepositorio _usuarioRepositorio;
        readonly IContextoValidacion _contextoValidacion;

        public AtuendosService(IGuardarropaRepositorio guardarropaRepositorio,
            IUsuarioRepositorio usuarioRepositorio,
            IContextoValidacion estrategiaValidacion)
        {
            _guardarropaRepositorio = guardarropaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _contextoValidacion = estrategiaValidacion;
        }

        public IEnumerable<Atuendo> GenerarAtuendosPorGuardarropa(int guardarropaId)
        {
            var guardarropa = _guardarropaRepositorio.ObtenerGuardarropaPorId(guardarropaId);

            var combinaciones = new Combinations<Prenda>(
                    guardarropa.Prendas.ToList(),
                    CantidadCategorias());

            return CrearAtuendos(combinaciones);
        }

        public IEnumerable<Atuendo> GenerarAtuendosPorUsuario(int usuarioId)
        {
            var usuario = _usuarioRepositorio.ObtenerUsuarioPorId(usuarioId);
            var atuendos = new List<Atuendo>();

            foreach (var guardarropa in usuario.Guardarropas)
            {
                atuendos.Concat(
                    GenerarAtuendosPorGuardarropa(
                        guardarropa.GuardarropaId));
            }

            return atuendos;
        }

        public IEnumerable<Atuendo> GenerarAtuendosPorEvento(int usuarioId,
            decimal? temperatura, Evento evento)
        {

                var usuario = _usuarioRepositorio.ObtenerUsuarioPorId(usuarioId);
                var atuendos = new List<Atuendo>();
                var capas = 0;

                foreach (var guardarropa in usuario.Guardarropas)
                {
                    var prendasFiltradas = FiltrarPrendas(guardarropa.Prendas, evento);

                    if (temperatura < 10)
                        capas = 2;
                    else if (temperatura >= 10 && temperatura < 20)
                        capas = 1;

                    var combinaciones = new Combinations<Prenda>(
                                prendasFiltradas,
                                Enum.GetNames(typeof(Categoria)).Length + capas
                            );

                    return CrearAtuendos(combinaciones, temperatura, capas);
                }

                return atuendos;
        }



        #region Métodos Privados

        private IEnumerable<Atuendo> CrearAtuendos(Combinations<Prenda> combinaciones, decimal? temperatura = 0, int capas = 0)
        {
            var combinacionesCorrectas = new List<List<Prenda>>();

            foreach (var combinacion in combinaciones)
            {
                _contextoValidacion.SetEstrategia(
                    new ValidadorAtuendo(combinacion, capas, temperatura));

                if (_contextoValidacion.RealizarValidacion())
                {
                    combinacionesCorrectas.Add(combinacion.ToList());
                }
            }
            return combinacionesCorrectas.Select(c => new Atuendo { Prendas = c });
        }

        private int CantidadCategorias()
        {
            return typeof(Categoria)
                .GetFields()
                .Select(p => p.GetCustomAttributes(typeof(Capas), false))
                .Skip(1)
                .Sum(x => ((Capas)x[0]).Cantidad);
        }

        //private IList<Prenda> FiltrarPrendas(ICollection<Prenda> prendas, TipoDeEvento tipoDeEvento)
        //{
        //    return prendas
        //        .Where(p =>
        //        {
        //            var props = p.Tipo.GetAttribute<PropiedadesTipoPrenda>();

        //            if (props == null)
        //                return true;

        //            return props.Formalidad >=
        //                   tipoDeEvento.GetAttribute<NivelDeFormalidad>().Nivel;
        //        })
        //        .ToList();
        //}
        private IList<Prenda> FiltrarPrendas(ICollection<Prenda> prendas, Evento evento)
        {
            return prendas
                .Where(p =>
                {
                    var props = p.Tipo.GetAttribute<PropiedadesTipoPrenda>();

                    if (props == null)
                        return true;

                    return props.Formalidad >= evento.Formalidad;
                })
                .ToList();
        }

        #endregion
    }
}
