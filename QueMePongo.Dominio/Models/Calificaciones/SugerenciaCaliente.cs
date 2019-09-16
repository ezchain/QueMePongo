using QueMePongo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Models
{
    public class SugerenciaCaliente :ICalificacion
    {
        public ISensibilidadLocal Manos { get; set; }
        public ISensibilidadLocal Cuello { get; set; }
        public ISensibilidadLocal Cabeza { get; set; }

        public SugerenciaCaliente(ICalificacionAccesorio manos, ICalificacionAccesorio cuello,
                                ICalificacionAccesorio cabeza)
        {
            Manos = manos.ObtenerCalificacionAccesorio(PosicionPrenda.Manos);
            Cuello = cuello.ObtenerCalificacionAccesorio(PosicionPrenda.Cuello);
            Cabeza = cabeza.ObtenerCalificacionAccesorio(PosicionPrenda.Cabeza);
        }
        public Usuario AjustarSensibilidad(Usuario usuario)
        {
            IList<ISensibilidadLocal> ListaSensibilidades = new List<ISensibilidadLocal>()
            {
                Manos,
                Cuello,
                Cabeza

            };
            usuario.Sensibilidad = new SensibilidadAcalorado(ListaSensibilidades);
            return usuario;
        }
    }
}
