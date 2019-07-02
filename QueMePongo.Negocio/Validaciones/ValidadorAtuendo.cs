using QueMePongo.Dominio.Interfaces.Validacion;
using QueMePongo.Dominio.Models;
using QueMePongo.Negocio.Helpers;
using System.Collections.Generic;

namespace QueMePongo.Negocio.Validaciones
{
    public class ValidadorAtuendo : IValidador
    {
        private readonly IList<Prenda> _combinacion;
        private readonly int _capas;

        public ValidadorAtuendo(IList<Prenda> combinacion, int capas)
        {
            _combinacion = combinacion;
            _capas = capas;
        }

        public bool Validar()
        {
            var categorias = new List<Categoria>();
            var tipos = new List<TipoDePrenda>();
            var capasAcumuladas = 0;
            var niveles = new List<int>();

            foreach (var prenda in _combinacion)
            {
                if (tipos.Contains(prenda.Tipo))
                    return false;

                if (categorias.Contains(prenda.Categoria))
                {
                    if (prenda.Categoria == Categoria.Torso && _capas > 0)
                    {
                        capasAcumuladas++;

                        if (capasAcumuladas > _capas || niveles.Contains(GetNivel(prenda)))
                            return false;

                        niveles.Add(GetNivel(prenda));
                    }
                    else
                        return false;
                }

                categorias.Add(prenda.Categoria);
                tipos.Add(prenda.Tipo);
            }

            return true;
        }

        private int GetNivel(Prenda prenda)
        {
            return prenda.Tipo.GetAttribute<PropiedadesTipoPrenda>().Nivel;
        }
    }
}
