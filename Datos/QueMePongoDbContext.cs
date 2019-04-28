using Datos.Configuraciones;
using Datos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class QueMePongoDbContext : DbContext
    {
        public QueMePongoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Prenda> Prendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PrendaConfiguracion(modelBuilder.Entity<Prenda>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
