using QueMePongo.Dominio.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueMePongo.Dominio.Interfaces.Servicios
{
    public interface ISugerenciasManager
    {
        void AgregarSolicitud(ISolicitud solicitud);
        Task<IEnumerable<Atuendo>> Procesar();
    }
}
