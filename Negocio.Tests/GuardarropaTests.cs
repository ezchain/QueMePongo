using Xunit;
using Moq;
using Datos.Repositorios;
using System.Collections.Generic;
using Datos.Entidades;
using System.Linq;

namespace Negocio.Tests
{
    public class GuardarropaTests
    {
        [Fact]
        public void DebeObtenerPrendas()
        {
            var repo = new Mock<IPrendasRepositorio>();
            repo.Setup(mock => mock.ObtenerPrendas())
                .Returns(new List<Prenda> { new Prenda { Id = 1, Nombre = "Pantalon" } });

            var guardarropa = new Guardarropa(repo.Object);

            var resultado = guardarropa.ObtenerPrendas();

            Assert.NotNull(resultado);
            Assert.Single(resultado);
            Assert.Equal(1, resultado.Single().Id);
            Assert.Equal("Pantalon", resultado.Single().Nombre);
        }

        [Fact]
        public void DebeObtenerShort()
        {
            var repo = new Mock<IPrendasRepositorio>();
            repo.Setup(mock => mock.ObtenerPrendas())
                .Returns(new List<Prenda> { new Prenda { Id = 2, Nombre = "Short de banio" } });

            var guardarropa = new Guardarropa(repo.Object);

            var resultado = guardarropa.ObtenerPrendas();

            Assert.NotNull(resultado);
            Assert.Single(resultado);
            Assert.Equal(2, resultado.Single().Id);
            Assert.Equal("Short de banio", resultado.Single().Nombre);
        }
        [Fact]
        public void DebeObtenerRemera()
        {
            var repo = new Mock<IPrendasRepositorio>();
            repo.Setup(mock => mock.ObtenerPrendas())
                .Returns(new List<Prenda> { new Prenda { Id = 3, Nombre = "Remera" } });

            var guardarropa = new Guardarropa(repo.Object);

            var resultado = guardarropa.ObtenerPrendas();

            Assert.NotNull(resultado);
            Assert.Single(resultado);
            Assert.Equal(3, resultado.Single().Id);
            Assert.Equal("Remera", resultado.Single().Nombre);
        }

        [Fact]
        public void DebeObtenerZapatos()
        {
            var repo = new Mock<IPrendasRepositorio>();
            repo.Setup(mock => mock.ObtenerPrendas())
                .Returns(new List<Prenda> { new Prenda { Id = 4, Nombre = "Zapatos" } });

            var guardarropa = new Guardarropa(repo.Object);

            var resultado = guardarropa.ObtenerPrendas();

            Assert.NotNull(resultado);
            Assert.Single(resultado);
            Assert.Equal(4, resultado.Single().Id);
            Assert.Equal("Zapatos", resultado.Single().Nombre);
        }
    }
}
