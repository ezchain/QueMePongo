using QueMePongo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Models
{
    public class SugerenciaMuyFria : ICalificacion
    {
        public ISensibilidadLocal Manos { get; set; }
        public ISensibilidadLocal Cuello { get; set; }
        public ISensibilidadLocal Cabeza { get; set; }

        public SugerenciaMuyFria(ICalificacionAccesorio manos, ICalificacionAccesorio cuello,
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
            usuario.Sensibilidad = new MuyFriolento(ListaSensibilidades);
            return usuario;
        }
    }
    public class SugerenciaFria : ICalificacion
    {
        public ISensibilidadLocal Manos { get; set; }
        public ISensibilidadLocal Cuello { get; set; }
        public ISensibilidadLocal Cabeza { get; set; }

        public SugerenciaFria(ICalificacionAccesorio manos, ICalificacionAccesorio cuello,
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
            usuario.Sensibilidad = new Friolento(ListaSensibilidades);
            return usuario;
        }
    }
    public class SugerenciaCaliente : ICalificacion
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
            usuario.Sensibilidad = new Acalorado(ListaSensibilidades);
            return usuario;
        }
    }
    public class SugerenciaMuyCaliente : ICalificacion
    {
        public ISensibilidadLocal Manos { get; set; }
        public ISensibilidadLocal Cuello { get; set; }
        public ISensibilidadLocal Cabeza { get; set; }

        public SugerenciaMuyCaliente(ICalificacionAccesorio manos, ICalificacionAccesorio cuello,
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
            usuario.Sensibilidad = new MuyAcalorado(ListaSensibilidades);
            return usuario;
        }
    }
    public class SugerenciaBien : ICalificacion
    {
        public ISensibilidadLocal Manos { get; set; }
        public ISensibilidadLocal Cuello { get; set; }
        public ISensibilidadLocal Cabeza { get; set; }

        public SugerenciaBien(ICalificacionAccesorio manos, ICalificacionAccesorio cuello,
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
            usuario.Sensibilidad = new Normal(ListaSensibilidades);
            return usuario;
        }
    }
    public class AccesorioFrio : ICalificacionAccesorio
    {
        public ISensibilidadLocal ObtenerCalificacionAccesorio(PosicionPrenda posicion)
        {
            return new FriolentoLocal(posicion);

        }
    }
    public class AccesorioCaliente : ICalificacionAccesorio
    {
        public ISensibilidadLocal ObtenerCalificacionAccesorio(PosicionPrenda posicion)
        {
            return new AcaloradoLocal(posicion);
        }
    }
    public class AccesorioBien : ICalificacionAccesorio
    {
        public ISensibilidadLocal ObtenerCalificacionAccesorio(PosicionPrenda posicion)
        {
            return new NormalLocal();
        }

    }


}
