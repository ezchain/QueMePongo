using QueMePongo.AccesoDatos.Data;
using QueMePongo.AccesoDatos.Entidades;
using QueMePongo.AccesoDatos.Repositorios;
using QueMePongo.AccesoDatos.Tests.Helpers;
using QueMePongo.Dominio.Models;
using QueMePongo.Dominio.TipoUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace QueMePongo.AccesoDatos.Tests.Repositorios
{
    public class GuardarropasRepositorioTests 
    {
        //[Fact]
        //public void DebeCrearUnGuardarropaConDosPrendas()
        //{
        //    //Arrange
        //    var guardarropa = new Guardarropa
        //    {
        //        Prendas = new List<Prenda>
        //            {
        //                new Prenda { Categoria = Categoria.Piernas, ColorPrimario = Color.Negro, Tela = Tela.Algodon, Tipo = new TipoDePrenda()  },
        //                new Prenda { Categoria = Categoria.Torso, ColorPrimario = Color.Blanco, Tela = Tela.Seda, Tipo = new TipoDePrenda()  }
        //            }
        //    };
        //    var repo = new GuardarropaRepositorio(_dbContext);

        //    //Act
        //    var respuesta = repo.CrearGuardarropa(guardarropa);

        //    //Assert
        //    Assert.NotNull(respuesta);
        //    Assert.Equal(2, guardarropa.Prendas.Count);
        //}

        //[Fact]
        //public void DebeEliminarUnaDeLasPrendasDeUnGuardarropa()
        //{
        //    //Arrange
        //    DbTestInitializer.InitializeGuardarropas(_dbContext);

        //    var guardarropa = _dbContext.Guardarropas.First();
        //    var prenda = guardarropa.Prendas.First();

        //    guardarropa.Prendas.Remove(prenda);

        //    var repo = new GuardarropaRepositorio(_dbContext);

        //    //Act
        //    repo.EditarGuardarropa(guardarropa);

        //    //Assert
        //    Assert.Null(_dbContext.Prendas.Find(prenda.PrendaId));
        //}

        //[Fact]
        //public void DebeAgregarUnaPrendasAUnGuardarropa()
        //{
        //    //Arrange
        //    DbTestInitializer.InitializeGuardarropas(_dbContext);

        //    var guardarropa = _dbContext.Guardarropas.First();

        //    guardarropa.Prendas.Add(new Prenda { Categoria = Categoria.Piernas, ColorPrimario = Color.Negro, Tela = Tela.Algodon, Tipo = new TipoDePrenda() });

        //    var repo = new GuardarropaRepositorio(_dbContext);

        //    //Act
        //    repo.EditarGuardarropa(guardarropa);

        //    //Assert
        //    Assert.Equal(5, _dbContext.Prendas.Count());
        //}

        [Fact]
        public void DBTest()
        {
          
            using (var context = new DbContext2())
            {

                //var std = new UsuarioEntity()
                //{
                //    UsuarioId = 3,
                //    Username = "alfsredo",


                //};

                //context.Usuarios.Add(std);
                //context.SaveChanges();
                //GuardarropaRepositorio repo = new GuardarropaRepositorio();
                //ICollection<Prenda> prendas = new List<Prenda>();
                //Prenda prenda = new Prenda()
                //{
                //    Categoria = Categoria.Piernas,
                //    ColorPrimario = Color.Azul,
                //    GuardarropaId = 1,
                //    Tela = Tela.Cuero,
                //    PrendaId = 1,
                //    Tipo = new TipoDePrenda()
                //    {
                //        Formalidad = Formalidad.Formal,
                //        Nivel = 1,
                //        Posicion = 2,
                //        Temperatura = 10
                //    }

                //};
                //prendas.Add(prenda);
                //Guardarropa guardarropa = new Guardarropa()
                //{
                //    GuardarropaId = 1,
                //    PrendasMaximas = 100,
                //    Usuarios = { 1, 2, 3, 4, 5 },
                //    Prendas = prendas
                //};
                //repo.CrearGuardarropa(guardarropa);
                UsuarioRepositorio repo = new UsuarioRepositorio();

                Usuario usuario = new Usuario()
                {
                    UsuarioId = 4,
                    Username = "asd",
                    Password = "asd",
                    Mail = "asd",
                    TipoUsuario = new Gratuito(),
                    Sensibilidad = new Normal()

                };
                  //  repo.CrearUsuario(usuario);
                Usuario user2 = repo.ObtenerUsuario(4);
                Evento evento = new Evento()
                {
                    EventoId = 1,
                    FechaInicio = DateTime.Now,
                    Formalidad = Formalidad.Formal,
                    Frecuencia = new Frecuencia(7),
                    Nombre = "resistance",
                    Ubicacion = new Ubicacion() { Latitud = "asd", Longitud = "asd" },
                    UsuarioId = 1
                };

                EventosRepositorio eventos = new EventosRepositorio();
                //eventos.CrearEvento(evento);
                evento = eventos.GetEvento(1);



            }
        }
    }
}
