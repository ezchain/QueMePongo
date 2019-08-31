using QueMePongo.Dominio.Models;
using System.Collections.Generic;

namespace QueMePongo.Dominio.DTOs
{
    public class Atuendo
    {
        public IList<Prenda> Prendas { get; set; }

        public double CalorTotal()
        {
            double Calor = 0;
            foreach (var prenda in Prendas)
            {
                Calor += prenda.Tipo.GetAttribute<PropiedadesTipoPrenda>().Temperatura;
            }
            return Calor;
        }
    }
}
