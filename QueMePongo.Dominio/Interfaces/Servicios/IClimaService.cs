using QueMePongo.Dominio.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QueMePongo.Dominio.Interfaces.Servicios
{
   public interface IClimaService
    {
        Task<Clima> ObtenerClima();
    }
}
