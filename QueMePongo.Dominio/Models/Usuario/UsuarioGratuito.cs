using QueMePongo.AccesoDatos.Repositorios.Interfaces;
using QueMePongo.Dominio.Interfaces;
using System;

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
