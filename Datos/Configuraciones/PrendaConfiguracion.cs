using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueMePongo.Dominio.Models;

namespace QueMePongo.AccesoDatos.Configuraciones
{
    public class PrendaConfiguracion : IEntityTypeConfiguration<Prenda>
    {
        public void Configure(EntityTypeBuilder<Prenda> builder)
        {
            builder.ToTable("Prendas");
        }
    }
}
