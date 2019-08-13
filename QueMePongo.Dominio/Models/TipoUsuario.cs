using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.TipoUsuario
{

    public class Gratuito : ITipoUsuario
    {

        public void AgregarPrenda(int idGuardarropa, Guardarropa guardarropa, Prenda prenda, IGuardarropaRepositorio guardarropaRepo)
        {
            if (guardarropa.Prendas.Count < guardarropa.PrendasMaximas)
            {
                guardarropaRepo.AgregarPrenda(idGuardarropa, prenda);
            }
            else
            {
                throw new InvalidOperationException("El guardarropa esta lleno");
            }


        }
    }

    public class Premium : ITipoUsuario
    {
        public void AgregarPrenda(int idGuardarropa, Guardarropa guardarropa, Prenda prenda, IGuardarropaRepositorio guardarropaRepo)
        {
            guardarropaRepo.AgregarPrenda(idGuardarropa, prenda);

        }

    }
}
