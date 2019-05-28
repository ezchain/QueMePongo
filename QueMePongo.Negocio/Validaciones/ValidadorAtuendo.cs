using Combinatorics.Collections;
using QueMePongo.Dominio.Interfaces.Validacion;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;
using System.Linq;

namespace QueMePongo.Negocio.Validaciones
{
    public class ValidadorAtuendo : IValidador
    {
        private readonly Combinations<Prenda> _combinaciones;
        private readonly List<List<Prenda>> _combinacionesCorrectas;

        public ValidadorAtuendo(Combinations<Prenda> combinaciones, List<List<Prenda>> combinacionesCorrectas)
        {
            _combinaciones = combinaciones;
            _combinacionesCorrectas = combinacionesCorrectas;
        }

        public void Validar()
        {
            foreach (var combinacion in _combinaciones)
            {
                var combinacionValida = combinacion
                    .GroupBy(p => p.Categoria)
                    .Count() == 5;

                if (combinacionValida)
                    _combinacionesCorrectas.Add(combinacion.ToList());
            }
        }
    }
}
