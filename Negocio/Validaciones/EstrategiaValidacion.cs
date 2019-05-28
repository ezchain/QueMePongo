using QueMePongo.Dominio.Interfaces.Validacion;

namespace QueMePongo.Negocio.Validaciones
{
    public class EstrategiaValidacion : IEstrategiaValidacion
    {
        private IValidador _validador;

        public void SetEstrategia(IValidador validador)
        {
            _validador = validador;
        }

        public void ReaalizarValidacion()
        {
            _validador.Validar();
        }
    }
}
