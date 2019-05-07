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
        public DbSet<Guardarropa> Guardarropas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Atuendo> Atuendos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = new PrendaConfiguracion(modelBuilder.Entity<Prenda>());
            base.OnModelCreating(modelBuilder);

            _ = new UsuarioConfiguracion(modelBuilder.Entity<Usuario>());
            base.OnModelCreating(modelBuilder);

            _ = new AtuendoConfiguracion(modelBuilder.Entity<Atuendo>());
            base.OnModelCreating(modelBuilder);

            _ = new GuardarropaConfiguracion(modelBuilder.Entity<Guardarropa>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
