using QueMePongo.Dominio.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueMePongo.Dominio.Interfaces
{
    public interface ISolicitud
    {
        Task<IEnumerable<Atuendo>> Ejecutar();
    }
}
