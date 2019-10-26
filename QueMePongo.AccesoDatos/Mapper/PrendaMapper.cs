using QueMePongo.AccesoDatos.Entidades;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.AccesoDatos.Mapper
{
    public static class PrendaMapper
    {
        public static PrendaEntity MapEntity(Prenda prenda)
        {
            return new PrendaEntity()
            {
                Nombre = prenda.Nombre,
                PrendaId = prenda.PrendaId,
                Categoria = ObtenerCategoria(prenda.Categoria),
                ColorPrimario = ObtenerColor(prenda.ColorPrimario),
                ColorSecundario = ObtenerColor(prenda.ColorSecundario),
                Tela = ObtenerTela(prenda.Tela),
                Formalidad = ObtenerFormalidad(prenda.Tipo.Formalidad),
                Nivel = prenda.Tipo.Nivel,
                Posicion = prenda.Tipo.Posicion,
                Temperatura = Convert.ToDecimal(prenda.Tipo.Temperatura),
                GuardarropaId = prenda.GuardarropaId,
                Imagen = prenda.Imagen

            };

        }

        public static Prenda MapModel(PrendaEntity entidad)
        {
            TipoDePrenda tipo = new TipoDePrenda()
            {
                Nivel = entidad.Nivel,
                Posicion = entidad.Posicion,
                Temperatura = Convert.ToDouble(entidad.Temperatura),
                Formalidad = ObtenerFormalidadEnum(entidad.Formalidad)
            };

            return new Prenda()
            {
                PrendaId = entidad.PrendaId,
                Imagen = entidad.Imagen,
                GuardarropaId = entidad.GuardarropaId,
                Categoria = ObtenerEnumCategoria(entidad.Categoria),
                ColorPrimario = ObtenerEnumColor(entidad.ColorPrimario),
                ColorSecundario = ObtenerEnumColorSecundario(entidad.ColorSecundario),
                Tela = ObtenerEnumTela(entidad.Tela),
                Tipo = tipo
            };
        }

        private static string ObtenerTela(Tela tela)
        {
            if (tela == Tela.Algodon) return "Algodon";
            if (tela == Tela.Cuero) return "Cuero";
            if (tela == Tela.Jena) return "Jena";
            if (tela == Tela.Lona) return "Lona";
            if (tela == Tela.Seda) return "Seda";
            return String.Empty;
        }

        private static string ObtenerColor(Color? color)
        {
            if (color == Color.Azul) return "Azul";
            if (color == Color.Blanco) return "Blanco";
            if (color == Color.Marron) return "Marron";
            if (color == Color.Negro) return "Negro";
            if (color == Color.Rojo) return "Rojo";
            if (color == Color.Verde) return "Verde";
            return String.Empty;
        }

        private static string ObtenerCategoria(Categoria categoria)
        {
            if (categoria == Categoria.Accesorio) return "Accesorio";
            if (categoria == Categoria.Cabeza) return "Cabeza";
            if (categoria == Categoria.Piernas) return "Piernas";
            if (categoria == Categoria.Pies) return "Pies";
            if (categoria == Categoria.Torso) return "Torso";
            return String.Empty;

        }

        private static Categoria ObtenerEnumCategoria(string categoria)
        {
            if (categoria.Equals("Accesorio")) return Categoria.Accesorio;
            if (categoria.Equals("Cabeza")) return Categoria.Cabeza;
            if (categoria.Equals("Piernas")) return Categoria.Piernas;
            if (categoria.Equals("Pies")) return Categoria.Pies;
            return Categoria.Torso;
        }

        private static Color ObtenerEnumColor(string color)
        {
            if (color.Equals("Azul")) return Color.Azul;
            if (color.Equals("Blanco")) return Color.Blanco;
            if (color.Equals("Marron")) return Color.Marron;
            if (color.Equals("Negro")) return Color.Negro;
            if (color.Equals("Rojo")) return Color.Rojo;
            return Color.Verde;

        }

        private static Color? ObtenerEnumColorSecundario(string color)
        {
            if (color.Equals("Azul")) return Color.Azul;
            if (color.Equals("Blanco")) return Color.Blanco;
            if (color.Equals("Marron")) return Color.Marron;
            if (color.Equals("Negro")) return Color.Negro;
            if (color.Equals("Rojo")) return Color.Rojo;
            if (color.Equals("Verde")) return Color.Verde;
            return null;

        }

        private static Tela ObtenerEnumTela(string tela)
        {
            if (tela.Equals("Algodon")) return Tela.Algodon;
            if (tela.Equals("Cuero")) return Tela.Cuero;
            if (tela.Equals("Jena")) return Tela.Jena;
            if (tela.Equals("Lona")) return Tela.Lona;
            return Tela.Seda;

        }
        private static string ObtenerFormalidad(Formalidad formalidad)
        {
            if (formalidad == Formalidad.Normal) return "Normal";
            if (formalidad == Formalidad.Formal) return "Formal";
            if (formalidad == Formalidad.Distendido) return "Distendido";
            return String.Empty;
        }

        private static Formalidad ObtenerFormalidadEnum(string formalidad)
        {
            if (formalidad.Equals("Normal")) return Formalidad.Normal;
            if (formalidad.Equals("Formal")) return Formalidad.Formal;
            return Formalidad.Distendido;

        }
    }
}
