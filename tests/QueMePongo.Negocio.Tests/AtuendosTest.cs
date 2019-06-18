using Combinatorics.Collections;
using QueMePongo.Dominio.Models;
using QueMePongo.Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Enum = QueMePongo.Dominio.Models.Categoria;

namespace Negocio.Tests
{
   public class AtuendosTest
    {
        [Fact]
        public void GenerarAtuendo()
        {
            Prenda Remera = new Prenda
            {
                Categoria = Enum.TorsoRemera
            };
            Prenda Camisa = new Prenda
            {
                Categoria = Enum.TorsoCamisa
            };
            Prenda Camiseta = new Prenda
            {
                Categoria = Enum.TorsoCamiseta
            };
            Prenda Campera = new Prenda
            {
                Categoria = Enum.TorsoCampera
            };
            Prenda Sueter = new Prenda
            {
                Categoria = Enum.TorsoSueter
            };
            Prenda OtroSueter = new Prenda
            {
                Categoria = Enum.TorsoSueter
            };
            IList<Prenda> prendas = new List<Prenda>
            {
                Remera,
                Camisa,
                Sueter,
                Camisa,
                Campera,
                Camiseta,
                OtroSueter
            };
            var combinaciones = new Combinations<Prenda>(prendas,5);
             AtuendosService service = new AtuendosService();
            var atuendos = service.CrearAtuendos(combinaciones);


        }
    }
}
