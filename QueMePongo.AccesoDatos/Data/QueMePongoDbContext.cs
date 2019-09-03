using Microsoft.EntityFrameworkCore;
using QueMePongo.AccesoDatos.Configuraciones;
using QueMePongo.Dominio.Models;

namespace QueMePongo.AccesoDatos.Data
{
    public class QueMePongoDbContext : DbContext
    {
        public QueMePongoDbContext(DbContextOptions<QueMePongoDbContext> options)
            : base(options)
        {

        }

        public DbSet<Prenda> Prendas { get; set; }
        public DbSet<Guardarropa> Guardarropas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PrendaConfiguracion());
        }
    }
}
