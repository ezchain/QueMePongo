using Microsoft.EntityFrameworkCore;
using QueMePongo.AccesoDatos.Configuraciones;
using QueMePongo.AccesoDatos.Entities;
using QueMePongo.Dominio.Models;

namespace QueMePongo.AccesoDatos.Data
{
    public class QueMePongoDbContext : DbContext
    {
        public QueMePongoDbContext(DbContextOptions<QueMePongoDbContext> options)
            : base(options)
        {

        }

        public DbSet<PrendaEntity> Prendas { get; set; }
        public DbSet<GuardarropaEntity> Guardarropas { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<EventoEntity> Eventos { get; set; }
        public DbSet<CategoriaEntity> Categorias { get; set; }
        public DbSet<ColorEntity> Colores { get; set; }
        public DbSet<FormalidadEntity> Formalidades { get; set; }
        public DbSet<FrecuenciaEventoEntity> Frecuencias { get; set; }
        public DbSet<SensibilidadEntity> Sensibilidades { get; set; }
        public DbSet<TelaEntity> Telas { get; set; }
        public DbSet<TipoDePrendaEntity> TiposDePrendas { get; set; }
        public DbSet<TipoUsuarioEntity> TiposDeUsuarios { get; set; }
        public DbSet<UbicacionEntity> Ubicaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PrendaConfiguracion());
        }
    }
}
