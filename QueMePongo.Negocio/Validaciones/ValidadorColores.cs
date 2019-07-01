using QueMePongo.Dominio.Interfaces.Validacion;
using QueMePongo.Dominio.Models;

namespace QueMePongo.Negocio.Validaciones
{
    public class ValidadorColores : IValidador
    {
        private readonly (Color colorPrim, Color? colorSec) _colores;

        public ValidadorColores((Color colorPrim, Color? colorSec) colores)
        {
            _colores = colores;
        }

        public bool Validar()
        {
            return _colores.colorPrim == _colores.colorSec;
        }
    }
}
