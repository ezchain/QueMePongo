using Moq;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Interfaces.Validacion;
using QueMePongo.Dominio.Models;
using QueMePongo.Negocio.Servicios;
using System.Linq;
using Xunit;
using QueMePongo.Negocio.Helpers;
using System.Collections.Generic;
using QueMePongo.Negocio.Validaciones;

namespace Negocio.Tests
{
    public class AtuendosTest
    {
        [Fact]
        public void DebeGenerarAtuendosPorGuardarropa()
        {
            Prenda[] prendas = new[]
            {
                new Prenda {Tipo= TipoDePrenda.Cartera, Categoria = Categoria.Accesorio },
                new Prenda {Tipo= TipoDePrenda.Gorra, Categoria = Categoria.Cabeza },
                new Prenda {Tipo= TipoDePrenda.Pantalon, Categoria = Categoria.Piernas },
                new Prenda {Tipo= TipoDePrenda.ZapatoHombre, Categoria = Categoria.Pies },
                new Prenda {Tipo= TipoDePrenda.Buzo, Categoria = Categoria.Torso },
                new Prenda {Tipo= TipoDePrenda.Remera, Categoria = Categoria.Torso }
            };

            var guardarropa = new Guardarropa { Prendas = prendas };
            var usuario = new Usuario { Guardarropas = new[] { guardarropa } };

            var guardarropaRepo = new Mock<IGuardarropaRepositorio>();
            var usuarioRepo = new Mock<IUsuarioRepositorio>();
            var contextoValidacion = new ContextoValidacion();

            usuarioRepo
                .Setup(mock => mock.ObtenerUsuarioPorId(It.IsAny<int>()))
                .Returns(usuario);

            var atuendosService = new AtuendosService(
                guardarropaRepo.Object, usuarioRepo.Object, contextoValidacion);

            var result = atuendosService.GenerarAtuendosPorEvento(1, 10, TipoDeEvento.IrATrabajar);

            Assert.Single(result);
        }
    }
}
