using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Interfaces.Validacion;
using QueMePongo.Dominio.Models;
using QueMePongo.Negocio.Validaciones;
using System.Collections.Generic;

namespace QueMePongo.Negocio.Servicios
{
    public class GuardarropasService : IGuardarropasService
    {
        readonly IGuardarropaRepositorio _guardarropaRepositorio;
        readonly IEstrategiaValidacion _estrategiaValidacion;

        public GuardarropasService(IGuardarropaRepositorio guardarropaRepositorio,
            IEstrategiaValidacion estrategiaValidacion)
        {
            _guardarropaRepositorio = guardarropaRepositorio;
            _estrategiaValidacion = estrategiaValidacion;
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

        public IList<Guardarropa> ObtenerGuardarropas()
        {
            return _guardarropaRepositorio.ObtenerGuardarropas();
        }

        #endregion

        #region Método(s) Privado(s)

        private void ValidarColores(ICollection<Prenda> prendas)
        {
            foreach (var prenda in prendas)
            {
                _estrategiaValidacion.SetEstrategia(
                    new ValidadorColores(
                        (prenda.ColorPrimario, prenda.ColorSecundario)));

                _estrategiaValidacion.RealizarValidacion();
            }
        }

        #endregion
    }
}
