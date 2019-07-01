using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Interfaces.Validacion;
using QueMePongo.Dominio.Models;
using QueMePongo.Negocio.Validaciones;
using System;
using System.Collections.Generic;

namespace QueMePongo.Negocio.Servicios
{
    public class GuardarropasService : IGuardarropasService
    {
        readonly IGuardarropaRepositorio _guardarropaRepositorio;
        readonly IContextoValidacion _contextoValidacion;

        public GuardarropasService(IGuardarropaRepositorio guardarropaRepositorio,
            IContextoValidacion estrategiaValidacion)
        {
            _guardarropaRepositorio = guardarropaRepositorio;
            _contextoValidacion = estrategiaValidacion;
        }

        #region Métodos Públicos

        public Guardarropa CrearGuardarropa(Guardarropa guardarropa)
        {
            ValidarColores(guardarropa.Prendas);

            return _guardarropaRepositorio.CrearGuardarropa(guardarropa);
        }

        public void EditarGuardarropa(Guardarropa guardarropa)
        {
            ValidarColores(guardarropa.Prendas);

            _guardarropaRepositorio.EditarGuardarropa(guardarropa);
        }

        public void EliminarGuardarropa(int id)
        {
            _guardarropaRepositorio.EliminarGuardarropa(id);
        }

        public Guardarropa ObtenerGuardarropaPorId(int id)
        {
            return _guardarropaRepositorio.ObtenerGuardarropaPorId(id);
        }

        public IEnumerable<Guardarropa> ObtenerGuardarropas()
        {
            return _guardarropaRepositorio.ObtenerGuardarropas();
        }

        #endregion

        #region Método(s) Privado(s)

        private void ValidarColores(ICollection<Prenda> prendas)
        {
            foreach (var prenda in prendas)
            {
                _contextoValidacion.SetEstrategia(
                            new ValidadorColores(
                                (prenda.ColorPrimario, prenda.ColorSecundario))
                        );

                if (_contextoValidacion.RealizarValidacion())
                    throw new InvalidOperationException("Combinacion de colores invalida");
            }
        }

        #endregion
    }
}
