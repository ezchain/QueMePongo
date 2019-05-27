using Datos.Entidades;
using Datos.Repositorios;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class Guardarropa : IGuardarropa
    {
        readonly IPrendasRepositorio _prendasRepositorio;
        readonly IGuardarropaRepositorio _guardarropaRepositorio;

        public Guardarropa(IPrendasRepositorio prendasRepositorio, IGuardarropaRepositorio guardarropaRepositorio)
        {
            _prendasRepositorio = prendasRepositorio;
            _guardarropaRepositorio = guardarropaRepositorio;
        }

        public IList<Prenda> ObtenerPrendas()
        {
            throw new NotImplementedException();
        }

        //public void AgregarPrenda(Prenda prenda)
        //{
        //    _guardarropaRepositorio.Prendas(Add);
        //}
        //Como era esto con Entity???
    }
}
