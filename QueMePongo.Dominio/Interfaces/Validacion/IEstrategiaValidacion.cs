using QueMePongo.Dominio.Interfaces;

namespace QueMePongo.Dominio.Interfaces.Validacion
{
    public interface IEstrategiaValidacion
    {
        void ReaalizarValidacion();
        void SetEstrategia(IValidador validador);
    }
}