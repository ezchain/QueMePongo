using System;

namespace QueMePongo.Dominio.Models
{
    public enum TipoDePrenda
    {
        [PropiedadesTipoPrenda(1, 10, 2)]
        RemeraMangaCorta = 1,

        [PropiedadesTipoPrenda(2, 20, 4)]
        Camisa = 2,

        [PropiedadesTipoPrenda(1, 15, 3)]
        Remera = 3,

        [PropiedadesTipoPrenda(2, 25, 4)]
        Sueter = 4,

        [PropiedadesTipoPrenda(2, 25, 4)]
        Buzo = 5,

        [PropiedadesTipoPrenda(3, 30, 4)]
        Campera = 6,

        [PropiedadesTipoPrenda(1, 5, 1)]
        Musculosa = 7,

        Pantalon = 8,
        Short = 9,
        ZapatoHombre = 10,
        ZapatoMujer = 11,
        ZapatillaMujer = 12,
        ZapatillaHombre = 13,
        Ojotas = 14,
        Gorra = 15,
        Cartera = 16
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class PropiedadesTipoPrenda : Attribute
    {
        public int Nivel { get; set; }
        public double Temperatura { get; set; }
        public int Formalidad { get; set; }

        public PropiedadesTipoPrenda(int nivel, double temperatura, int formalidad)
        {
            Nivel = nivel;
            Temperatura = temperatura;
            Formalidad = formalidad;
        }
    }
}
