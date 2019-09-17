using QueMePongo.AccesoDatos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.AccesoDatos.Repositorios.Interfaces
{
    public interface IPrendasRepositorio
    {
        IEnumerable<PrendaEntity> GetPrendas();
        PrendaEntity GetPrenda(int id);
        void AddPrenda(PrendaEntity prenda);
        void UpdatePrenda(PrendaEntity prenda);
        void DeletePrenda(int id);
    }
}
