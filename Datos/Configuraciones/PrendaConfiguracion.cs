using Datos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos.Configuraciones
{
    public class PrendaConfiguracion
    {
        public PrendaConfiguracion(EntityTypeBuilder<Prenda> typeBuilder)
        {
            typeBuilder.ToTable("Prendas");
            typeBuilder.HasKey(prenda => prenda.Id);
            typeBuilder.Property(prenda => prenda.Nombre);
        }
    }
}
