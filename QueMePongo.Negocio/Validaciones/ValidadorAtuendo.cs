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
        private readonly decimal? _temperatura;

        public ValidadorAtuendo(IList<Prenda> combinacion, int capas, decimal? temperatura)
        {
            _combinacion = combinacion;
            _capas = capas;
            _temperatura = temperatura;
        }

        public bool Validar()
        {
            var categorias = new List<Categoria>();
            var tipos = new List<TipoDePrenda>();
            var capasAcumuladas = 0;
            var niveles = new List<int>();
            double temperatura = 0;

            foreach (var prenda in _combinacion)
            {
                var propsPrenda = prenda.Tipo.GetAttribute<PropiedadesTipoPrenda>();

                if (tipos.Contains(prenda.Tipo)
                    || (prenda.Categoria != Categoria.Torso
                        && propsPrenda != null
                        && propsPrenda.Temperatura < (double)_temperatura))
                    return false;

                if (prenda.Categoria == Categoria.Torso
                    && propsPrenda.Temperatura < (double)_temperatura
                    && _capas == 0)
                    return false;

                if (categorias.Contains(prenda.Categoria))
                {
                    if (prenda.Categoria == Categoria.Torso && _capas > 0)
                    {
                        capasAcumuladas++;
                        temperatura += propsPrenda.Temperatura;

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

            if (temperatura < (double)_temperatura && _capas > 0)
                return false;

            return true;
        }

        private int GetNivel(Prenda prenda)
        {
            return prenda.Tipo.GetAttribute<PropiedadesTipoPrenda>().Nivel;
        }
    }
}
