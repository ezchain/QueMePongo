using Moq;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using QueMePongo.Negocio.Servicios;
using System.Linq;
using Xunit;
using QueMePongo.Negocio.Validaciones;

namespace Negocio.Tests
{
    public class AtuendosTest
    {
        private Prenda[] _prendas => new[]
            {
                new Prenda { PrendaId = 1, Tipo= TipoDePrenda.Cartera, Categoria = Categoria.Accesorio },
                new Prenda { PrendaId = 2, Tipo= TipoDePrenda.Gorra, Categoria = Categoria.Cabeza },
                new Prenda { PrendaId = 2, Tipo= TipoDePrenda.Nada, Categoria = Categoria.Cabeza },
                new Prenda { PrendaId = 3, Tipo= TipoDePrenda.Pantalon, Categoria = Categoria.Piernas },
                new Prenda { PrendaId = 4, Tipo= TipoDePrenda.ZapatoHombre, Categoria = Categoria.Pies },
                new Prenda { PrendaId = 5, Tipo= TipoDePrenda.Buzo, Categoria = Categoria.Torso },
                new Prenda { PrendaId = 6, Tipo= TipoDePrenda.Remera, Categoria = Categoria.Torso },
                new Prenda { PrendaId = 7, Tipo= TipoDePrenda.Musculosa, Categoria = Categoria.Torso },
                new Prenda { PrendaId = 8, Tipo= TipoDePrenda.Ojotas, Categoria = Categoria.Pies },
                new Prenda { PrendaId = 9, Tipo= TipoDePrenda.Short, Categoria = Categoria.Piernas }
            };

        [Fact]
        public void DebeObtenerUnAtuendo_DeInvierno_Formal_Para_IrATrabajar()
        {
            //Arrange
            const decimal TEMPERATURA = 10;

            var guardarropa = new Guardarropa { Prendas = _prendas };
            var usuario = new Usuario { Guardarropas = new[] { guardarropa } };

            var guardarropaRepo = new Mock<IGuardarropaRepositorio>();
            var usuarioRepo = new Mock<IUsuarioRepositorio>();
            var contextoValidacion = new ContextoValidacion();

            usuarioRepo
                .Setup(mock => mock.ObtenerUsuarioPorId(It.IsAny<int>()))
                .Returns(usuario);

            var atuendosService = new AtuendosService(
                guardarropaRepo.Object, usuarioRepo.Object, contextoValidacion);

            //Act
            var result = atuendosService
                .GenerarAtuendosPorEvento(1, TEMPERATURA, new Evento("Ir a trabajar",10,FrecuenciaEvento.Diaria));

            //Assert
            Assert.Single(result);
            Assert.Equal(6, result.First().Prendas.Count);

            var tipos = result.First().Prendas.Select(p => p.Tipo);
            Assert.DoesNotContain(TipoDePrenda.Short, tipos);
            Assert.DoesNotContain(TipoDePrenda.Ojotas, tipos);
            Assert.DoesNotContain(TipoDePrenda.Musculosa, tipos);
            Assert.DoesNotContain(TipoDePrenda.Gorra, tipos);
        }

        [Fact]
        public void DebeObtenerUnAtuendo_DeInvierno_Informal_Para_SalirConAmigos()
        {
            //Arrange
            const decimal TEMPERATURA = 10;

            var guardarropa = new Guardarropa { Prendas = _prendas };
            var usuario = new Usuario { Guardarropas = new[] { guardarropa } };

            var guardarropaRepo = new Mock<IGuardarropaRepositorio>();
            var usuarioRepo = new Mock<IUsuarioRepositorio>();
            var contextoValidacion = new ContextoValidacion();

            usuarioRepo
                .Setup(mock => mock.ObtenerUsuarioPorId(It.IsAny<int>()))
                .Returns(usuario);

            var atuendosService = new AtuendosService(
                guardarropaRepo.Object, usuarioRepo.Object, contextoValidacion);

            //Act
            var result = atuendosService
                .GenerarAtuendosPorEvento(1, TEMPERATURA, new Evento("Salir con amigos", 10, FrecuenciaEvento.Diaria));

            //Assert
            Assert.Equal(4, result.Count());
            Assert.Equal(6, result.First().Prendas.Count);
        }
    }
}
