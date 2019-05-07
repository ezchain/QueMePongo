using Datos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Configuraciones
{
    public class GuardarropaConfiguracion
    {
        public GuardarropaConfiguracion(EntityTypeBuilder<Guardarropa> typeBuilder)
        {
            typeBuilder.ToTable("Guardarropas");
            typeBuilder.HasKey(guardarropa => guardarropa.Id);
            typeBuilder.Property<List<Prenda>>(guardarropa => guardarropa.Prendas);
            
        }
    }
}
