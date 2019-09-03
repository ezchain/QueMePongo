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

        /// <summary>
        /// Genera atuendos para un determinado evento
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="temperatura"></param>
        /// <param name="evento"></param>
        /// <returns></returns>
        public IEnumerable<Atuendo> GenerarAtuendosPorEvento(decimal? temperatura, Evento evento)
        {

            var usuario = _usuarioRepositorio.ObtenerUsuarioPorId(evento.UsuarioId);
            int capas = ObtenerCapasPorTemperatura(temperatura);
            capas = usuario.Sensibilidad.ObtenerSensibilidadGlobal(capas);
            return GenerarCombinaciones(usuario, evento, temperatura, capas);
        }

        /// <summary>
        /// Valida que una sugerencia no haya sido aceptada por otro usuario
        /// </summary>
        /// <param name="atuendo"></param>
        /// <returns></returns>
        public bool ValidarSugerencia(Atuendo atuendo, int idUsuario)
        {
            IList<Sugerencia> SugerenciasActivas = new List<Sugerencia>();//traeria las sugerencias de la base
            return !SugerenciasActivas.Any(p => p.Atuendo.Equals(atuendo) && p.Aceptada && p.UsuarioId != idUsuario);
        }

        #region Métodos Privados

        private IEnumerable<Atuendo> GenerarCombinaciones(Usuario usuario, Evento evento, decimal? temperatura, int capas)
        {
            IList<Atuendo> atuendos = new List<Atuendo>();

            foreach (var guardarropa in usuario.Guardarropas)
            {
                var prendasFiltradas = FiltrarPrendasEvento(guardarropa.Prendas, evento);

                var combinaciones = new Combinations<Prenda>(
                            prendasFiltradas,
                            Enum.GetNames(typeof(Categoria)).Length + capas
                        );

                atuendos.Concat(
                    CrearAtuendos(combinaciones, temperatura, capas));
            }

            return usuario.Sensibilidad.SensibilidadLocal(atuendos);
        }

        private int ObtenerCapasPorTemperatura(decimal? temperatura)
        {
            if (temperatura < 10) return 3;
            else if (temperatura >= 10 && temperatura < 20) return 2;
            else return 1;
        }

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

        //Deberia filtrar las prendas que son lo suficientemente formales para el evento en cuestion
        private IList<Prenda> FiltrarPrendasEvento(ICollection<Prenda> prendas, Evento evento)
        {
            return prendas
                .Where(p => p.Tipo.Formalidad == evento.Formalidad)
                .ToList();
        }

        #endregion
    }
}
