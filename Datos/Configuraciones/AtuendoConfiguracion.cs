using Datos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Configuraciones
{
    public class AtuendoConfiguracion
    {
        public AtuendoConfiguracion(EntityTypeBuilder<Atuendo> typeBuilder)
        {
            typeBuilder.ToTable("Atuendos");
            typeBuilder.HasKey(atuendo => atuendo.Id);
            typeBuilder.Property<List<Prenda>>(atuendo => atuendo.Prendas);
        }
    }
}
