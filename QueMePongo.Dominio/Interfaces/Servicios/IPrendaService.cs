using Microsoft.AspNetCore.Http;
using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Interfaces.Servicios
{
    public interface IPrendaService
    {
        IEnumerable<Prenda> GetPrendas();
        Prenda GetPrenda(int id);
        void AddPrenda(PrendaDTO prenda, IFormFile imagen);
        void UpdatePrenda(Prenda prenda);
        void DeletePrenda(int id);
    }
}
