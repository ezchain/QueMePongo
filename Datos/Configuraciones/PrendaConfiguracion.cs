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
            typeBuilder.Property(prenda => prenda.Categoria);
            typeBuilder.Property(prenda => prenda.Tipo);
            typeBuilder.Property(prenda => prenda.Tela);
            typeBuilder.Property(prenda => prenda.ColorPrimario);
            typeBuilder.Property(prenda => prenda.ColorSecundario);
        }
    }
}
