using System;

namespace QueMePongo.Dominio.Models
{
    public enum TipoDePrenda
    {
        [PropiedadesTipoPrenda(10, 2, 1,3)]
        RemeraMangaCorta = 1,

        [PropiedadesTipoPrenda(20, 4, 2,3)]
        Camisa = 2,

        [PropiedadesTipoPrenda(15, 3, 1,3)]
        Remera = 3,

        [PropiedadesTipoPrenda(25, 4, 2,3)]
        Sueter = 4,

        [PropiedadesTipoPrenda(25, 4, 2,3)]
        Buzo = 5,

        [PropiedadesTipoPrenda(30, 4, 3,3)]
        Campera = 6,

        [PropiedadesTipoPrenda(5, 1, 1,3)]
        Musculosa = 7,

        [PropiedadesTipoPrenda(30, 3,0,2)]
        Pantalon = 8,

        [PropiedadesTipoPrenda(10, 1,0,2)]
        Short = 9,

        [PropiedadesTipoPrenda(15, 3,0,1)]
        ZapatoHombre = 10,

        [PropiedadesTipoPrenda(15, 3,0,1)]
        ZapatoMujer = 11,

        [PropiedadesTipoPrenda(15, 2,0,1)]
        ZapatillaMujer = 12,

        [PropiedadesTipoPrenda(15, 2,0,1)]
        ZapatillaHombre = 13,

        [PropiedadesTipoPrenda(5, 1,0,1)]
        Ojotas = 14,

        [PropiedadesTipoPrenda(10,1,0,4)]
        Guantes = 15,

        [PropiedadesTipoPrenda(10, 1, 0, 5)]
        Bufanda = 16,

        [PropiedadesTipoPrenda(10,1,0,6)]
        Gorra = 17,

        Cartera = 18,
        Nada = 100
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class PropiedadesTipoPrenda : Attribute
    {
        public int Nivel { get; set; }
        public double Temperatura { get; set; }
        public int Formalidad { get; set; }
        public int Posicion { get; set; }

        public PropiedadesTipoPrenda(double temperatura, int formalidad, int nivel,int posicion)
        {
            Nivel = nivel;
            Temperatura = temperatura;
            Formalidad = formalidad;
            Posicion = posicion;
        }
    }
}
