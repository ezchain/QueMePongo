using Combinatorics.Collections;
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

            var combinaciones = new Combinations<Prenda>(
                usuario.Guardarropas.SelectMany(gr => gr.Prendas).ToList(), 5);

            return CrearAtuendos(combinaciones);
        }

        private IEnumerable<Atuendo> CrearAtuendos(Combinations<Prenda> combinaciones)
        {
            _estrategiaValidacion.SetEstrategia(new ValidadorAtuendo(combinaciones));
            _estrategiaValidacion.RealizarValidacion();

            return combinaciones.Select(c => new Atuendo { Prendas = c });
        }
    }
}
