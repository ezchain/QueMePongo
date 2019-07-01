using QueMePongo.Dominio.Interfaces.Validacion;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;

namespace QueMePongo.Negocio.Validaciones
{
    public class ValidadorAtuendo : IValidador
    {
        private readonly IList<Prenda> _combinacion;

        public ValidadorAtuendo(IList<Prenda> combinacion)
        {
            _combinacion = combinacion;
        }

        public bool Validar()
        {
            var categorias = new List<Categoria>();

            foreach (var prenda in _combinacion)
            {
                if (categorias.Contains(prenda.Categoria))
                {
                    return false;
                }
                categorias.Add(prenda.Categoria);
            }

            return true;
        }
    }
}
