using QueMePongo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Models
{
    public class UsuarioGratuito : ITipoUsuario
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
}
