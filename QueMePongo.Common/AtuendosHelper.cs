using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueMePongo.Common
{
    public class AtuendosHelper
    {
        public bool AtuendoTieneCategoria(int categoria,Atuendo atuendo)
        {
            foreach(var prenda in atuendo.Prendas)
            {
                return prenda.Tipo.GetAttribute<PropiedadesTipoPrenda>().;
            }
        }
    }
}
