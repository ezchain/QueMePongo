namespace QueMePongo.Dominio.Interfaces.Validacion
{
    public interface IContextoValidacion
    {
        bool RealizarValidacion();
        void SetEstrategia(IValidador validador);
    }
}