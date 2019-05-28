using Combinatorics.Collections;
using QueMePongo.Dominio.Interfaces.Validacion;
using QueMePongo.Dominio.Models;
using System;
using System.Linq;

namespace QueMePongo.Negocio.Validaciones
{
    public class ValidadorAtuendo : IValidador
    {
        private readonly Combinations<Prenda> _combinaciones;

        public ValidadorAtuendo(Combinations<Prenda> combinaciones)
        {
            _combinaciones = combinaciones;
        }

        public void Validar()
        {
            foreach (var combinacion in _combinaciones)
            {
                var prendaValida = combinacion
                    .GroupBy(p => p.Categoria)
                    .Count() == 5;

                if (!prendaValida)
                    throw new Exception("Combinación de prendas no válidas");
            }
        }
    }
}
