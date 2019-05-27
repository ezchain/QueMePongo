using System.Collections.Generic;
using QueMePongo.Dominio.DTOs;

namespace QueMePongo.Dominio.Interfaces.Managers
{
    public interface IAtuendosManager
    {
        IEnumerable<Atuendo> GenerarAtuendosPorGuardarropa(int guardarropaId);
    }
}