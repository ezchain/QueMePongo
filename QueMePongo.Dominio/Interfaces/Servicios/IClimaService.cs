using QueMePongo.Dominio.DTOs;
using System.Threading.Tasks;

namespace QueMePongo.Dominio.Interfaces.Servicios
{
    public interface IClimaService
    {
        Task<Clima> ObtenerClima(string coordenadas);
    }
}
