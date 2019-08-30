using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueMePongo.Dominio
{
   public static class Helper
    {
        public static double DiasEnMilisegundos(double dias)
        {
            return 1000 * 60 * 60 * 24 * dias;
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);

            return enumType.GetField(name).GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }

        public static bool AtuendoTienePosicion(Atuendo atuendo,int posicion)
        {
            foreach(var prenda in atuendo.Prendas)
            {
                return prenda.Tipo.GetAttribute<PropiedadesTipoPrenda>().Posicion == posicion;
            }
            return false;
        }
    }
}
