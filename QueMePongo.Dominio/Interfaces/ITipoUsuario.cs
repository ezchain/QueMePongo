using QueMePongo.AccesoDatos.Repositorios.Interfaces;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Interfaces
{
  public interface ITipoUsuario
    {
        void AgregarPrenda(int idGuardarropa, Guardarropa guardarropa, Prenda prenda, IGuardarropaRepositorio guardarropaRepo);
    }
}
