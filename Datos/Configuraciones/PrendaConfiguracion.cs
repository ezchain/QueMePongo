using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QueMePongo.Dominio.Models;

namespace QueMePongo.AccesoDatos.Configuraciones
{
    public class PrendaConfiguracion : IEntityTypeConfiguration<Prenda>
    {
        public void Configure(EntityTypeBuilder<Prenda> builder)
        {
            var converterColor = new EnumToNumberConverter<Color, int>();
            var converterCategoria = new EnumToNumberConverter<Categoria, int>();
            var converterTela = new EnumToNumberConverter<Tela, int>();
            var converterTipo = new EnumToNumberConverter<Tipo, int>();

            builder.Property(b => b.Tipo)
                .IsRequired()
                .HasConversion(converterTipo);

            builder.Property(b => b.Tela)
                .IsRequired()
                .HasConversion(converterTela);

            builder.Property(b => b.Categoria)
                .IsRequired()
                .HasConversion(converterCategoria);

            builder.Property(b => b.ColorPrimario)
                .IsRequired()
                .HasConversion(converterColor);

            builder.Property(b => b.ColorSecundario)
                .IsRequired()
                .HasConversion(converterColor);
        }
    }
}
