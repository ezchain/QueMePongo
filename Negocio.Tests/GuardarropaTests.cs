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
            var repo = new Mock<PrendasRepositorio>();
            repo.Setup(mock => mock.ObtenerPrendas())
                .Returns(new List<Prenda> { new Prenda { Id = 1, Nombre = "Pantalon"} });

            var guardarropa = new Guardarropa(repo.Object);

            var resultado = guardarropa.ObtenerPrendas();

            Assert.NotNull(resultado);
            Assert.Single(resultado);
            Assert.Equal(1, resultado.Single().Id);
            Assert.Equal("Pantalon", resultado.Single().Nombre);
        }
    }
}
