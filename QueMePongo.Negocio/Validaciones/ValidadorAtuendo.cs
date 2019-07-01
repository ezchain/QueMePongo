using QueMePongo.Dominio.Interfaces.Validacion;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.Negocio.Validaciones
{
    public static class ValidadorAtuendo 
    {
        private readonly IList<Prenda> _combinacion;

        public ValidadorAtuendo(IList<Prenda> combinacion)
        {
            _combinacion = combinacion;
        }

        public bool Validar()
        {
            return _combinacion.GroupBy(p => p.Categoria).Count() == 5;
        }
    }
}
