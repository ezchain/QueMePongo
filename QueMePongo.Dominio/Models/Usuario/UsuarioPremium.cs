using QueMePongo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Models
{
    public class UsuarioPremium : ITipoUsuario
    {
        public void AgregarPrenda(int idGuardarropa, Guardarropa guardarropa, Prenda prenda, IGuardarropaRepositorio guardarropaRepo)
        {
            guardarropaRepo.AgregarPrenda(idGuardarropa, prenda);
        }
    }
}
