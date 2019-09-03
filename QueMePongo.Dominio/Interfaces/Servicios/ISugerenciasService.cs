using System.Threading.Tasks;
using QueMePongo.Dominio.Models;

namespace QueMePongo.Dominio.Interfaces.Servicios
{
    public interface ISugerenciasService
    {
        void AceptarSugerencia(Sugerencia sugerencia);
        Task<Sugerencia> GenerarSugerencia(Evento evento);
        Sugerencia RechazarSugerencia(Sugerencia sugerencia);
    }
}