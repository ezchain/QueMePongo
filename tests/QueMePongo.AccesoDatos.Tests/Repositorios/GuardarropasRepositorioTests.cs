using QueMePongo.AccesoDatos.Repositorios;
using QueMePongo.AccesoDatos.Tests.Helpers;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace QueMePongo.AccesoDatos.Tests.Repositorios
{
    public class GuardarropasRepositorioTests : DbContextTestBase
    {
        [Fact]
        public void DebeCrearUnGuardarropaConDosPrendas()
        {
            //Arrange
            var guardarropa = new Guardarropa
            {
                Prendas = new List<Prenda>
                    {
                        new Prenda { Categoria = Categoria.Piernas, ColorPrimario = Color.Negro, Tela = Tela.Algodon, Tipo = new TipoDePrenda()  },
                        new Prenda { Categoria = Categoria.Torso, ColorPrimario = Color.Blanco, Tela = Tela.Seda, Tipo = new TipoDePrenda()  }
                    }
            };
            var repo = new GuardarropaRepositorio(_dbContext);

            //Act
            var respuesta = repo.CrearGuardarropa(guardarropa);

            //Assert
            Assert.NotNull(respuesta);
            Assert.Equal(2, guardarropa.Prendas.Count);
        }

        [Fact]
        public void DebeEliminarUnaDeLasPrendasDeUnGuardarropa()
        {
            //Arrange
            DbTestInitializer.InitializeGuardarropas(_dbContext);

            var guardarropa = _dbContext.Guardarropas.First();
            var prenda = guardarropa.Prendas.First();

            guardarropa.Prendas.Remove(prenda);

            var repo = new GuardarropaRepositorio(_dbContext);

            //Act
            repo.EditarGuardarropa(guardarropa);

            //Assert
            Assert.Null(_dbContext.Prendas.Find(prenda.PrendaId));
        }

        [Fact]
        public void DebeAgregarUnaPrendasAUnGuardarropa()
        {
            //Arrange
            DbTestInitializer.InitializeGuardarropas(_dbContext);

            var guardarropa = _dbContext.Guardarropas.First();

            guardarropa.Prendas.Add(new Prenda { Categoria = Categoria.Piernas, ColorPrimario = Color.Negro, Tela = Tela.Algodon, Tipo = new TipoDePrenda() });

            var repo = new GuardarropaRepositorio(_dbContext);

            //Act
            repo.EditarGuardarropa(guardarropa);

            //Assert
            Assert.Equal(5, _dbContext.Prendas.Count());
        }
    }
}
