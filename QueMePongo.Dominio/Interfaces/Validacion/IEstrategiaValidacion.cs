using QueMePongo.Dominio.Interfaces;

namespace QueMePongo.Dominio.Interfaces.Validacion
{
    public interface IEstrategiaValidacion
    {
        void RealizarValidacion();
        void SetEstrategia(IValidador validador);
    }
}