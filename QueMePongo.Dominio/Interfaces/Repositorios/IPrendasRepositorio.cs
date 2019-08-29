using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Interfaces.Repositorios
{
    public interface IPrendasRepositorio
    {
        IEnumerable<Prenda> GetPrendas();
        Prenda GetPrenda(int id);
        void AddPrenda(Prenda prenda);
        void UpdatePrenda(Prenda prenda);
        void DeletePrenda(int id);
    }
}
