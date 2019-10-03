using QueMePongo.Dominio.DTOs;
using System;
using System.Linq;

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

        public static bool AtuendoTienePosicion(Atuendo atuendo, int posicion)
        {
            foreach (var prenda in atuendo.Prendas)
            {
                return prenda.Tipo.Posicion == posicion;
            }
            return false;
        }
        public static string Frecuencia(double dias)
        {
            if (dias == 365) return "Anual";
            if (dias == 7) return "Semanal";
            if (dias == 1) return "Diario";
            if (dias == 30 || dias == 31) return "Mensual";
            return String.Empty;
        }
    }
}
