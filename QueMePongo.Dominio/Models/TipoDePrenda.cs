using System;

namespace QueMePongo.Dominio.Models
{
    public enum TipoDePrenda
    {
        [PropiedadesTipoPrenda(10, 2, 1)]
        RemeraMangaCorta = 1,

        [PropiedadesTipoPrenda(20, 4, 2)]
        Camisa = 2,

        [PropiedadesTipoPrenda(15, 3, 1)]
        Remera = 3,

        [PropiedadesTipoPrenda(25, 4, 2)]
        Sueter = 4,

        [PropiedadesTipoPrenda(25, 4, 2)]
        Buzo = 5,

        [PropiedadesTipoPrenda(30, 4, 3)]
        Campera = 6,

        [PropiedadesTipoPrenda(5, 1, 1)]
        Musculosa = 7,

        [PropiedadesTipoPrenda(30, 3)]
        Pantalon = 8,

        [PropiedadesTipoPrenda(10, 1)]
        Short = 9,

        [PropiedadesTipoPrenda(15, 3)]
        ZapatoHombre = 10,

        [PropiedadesTipoPrenda(15, 3)]
        ZapatoMujer = 11,

        [PropiedadesTipoPrenda(15, 2)]
        ZapatillaMujer = 12,

        [PropiedadesTipoPrenda(15, 2)]
        ZapatillaHombre = 13,

        [PropiedadesTipoPrenda(5, 1)]
        Ojotas = 14,

        [PropiedadesTipoPrenda(10, 1)]
        Gorra = 15,

        Cartera = 16,
        Nada = 100
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class PropiedadesTipoPrenda : Attribute
    {
        public int Nivel { get; set; }
        public double Temperatura { get; set; }
        public int Formalidad { get; set; }

        public PropiedadesTipoPrenda(double temperatura, int formalidad, int nivel = 0)
        {
            Nivel = nivel;
            Temperatura = temperatura;
            Formalidad = formalidad;
        }
    }
}
