﻿using QueMePongo.AccesoDatos.Data;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;

namespace QueMePongo.AccesoDatos.Tests.Helpers
{
    public class DbTestInitializer
    {
        public static void InitializeGuardarropas(QueMePongoDbContext dbContext)
        {
            var guardarropas = new[]
            {
                new Guardarropa
                {
                    Prendas = new List<Prenda>
                    {
                        new Prenda { Categoria = Categoria.Piernas, ColorPrimario = Color.Negro, Tela = Tela.Algodon, Tipo = TipoDePrenda.Pantalon },
                        new Prenda { Categoria = Categoria.Torso, ColorPrimario = Color.Blanco, Tela = Tela.Seda, Tipo = TipoDePrenda.Camisa }
                    }
                },
                new Guardarropa
                {
                    Prendas = new List<Prenda>
                    {
                        new Prenda { Categoria = Categoria.Cabeza, ColorPrimario = Color.Rojo, Tela = Tela.Jena, Tipo = TipoDePrenda.Short },
                        new Prenda { Categoria = Categoria.Pies, ColorPrimario = Color.Negro, Tela = Tela.Cuero, Tipo = TipoDePrenda.ZapatoHombre }
                    }
                }
            };

            dbContext.AddRange(guardarropas);
            dbContext.SaveChanges();
        }
    }
}
