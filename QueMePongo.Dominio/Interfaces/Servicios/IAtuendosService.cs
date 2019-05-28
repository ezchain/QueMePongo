using System.Collections.Generic;
using QueMePongo.Dominio.DTOs;

namespace QueMePongo.Dominio.Interfaces.Servicios
{
    public interface IAtuendosService
    {
        IEnumerable<Atuendo> GenerarAtuendosPorGuardarropa(int guardarropaId);
    }
}