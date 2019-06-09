using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Negocio.Tests
{
    public class ClimaTest
    {
      [Fact]
      public void ObtenerClima()
        {
            IClimaService clima = new ClimaService();
          var climaObt =  clima.ObtenerClima();
            var clima2 = clima.ObtenerClimaDarkAPI();
        }
    }
}
