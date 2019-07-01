using Combinatorics.Collections;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;
using Xunit;

namespace Negocio.Tests
{
    public class AtuendosTest
    {
        [Fact]
        public void GenerarAtuendo()
        {
            Prenda Remera = new Prenda
            {
                Categoria = Categoria.Torso,
                Tipo = Tipo.Remera
            };
            Prenda Camisa = new Prenda
            {
                Categoria = Categoria.Torso,
                Tipo = Tipo.Camisa
            };
            Prenda Campera = new Prenda
            {
                Categoria = Categoria.Torso,
                Tipo = Tipo.Campera
            };
            Prenda Sueter = new Prenda
            {
                Categoria = Categoria.Torso,
                Tipo = Tipo.Sueter
            };
            Prenda OtroSueter = new Prenda
            {
                Categoria = Categoria.Torso,
                Tipo = Tipo.Sueter
            };
            IList<Prenda> prendas = new List<Prenda>
            {
                Remera,
                Camisa,
                Sueter,
                Camisa,
                Campera,
                OtroSueter
            };
            var combinaciones = new Combinations<Prenda>(prendas, 5);
        }
    }
}
