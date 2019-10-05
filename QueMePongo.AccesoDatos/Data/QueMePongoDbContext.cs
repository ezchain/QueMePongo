using Microsoft.EntityFrameworkCore;
using QueMePongo.AccesoDatos.Configuraciones;
using QueMePongo.AccesoDatos.Entidades;
using QueMePongo.AccesoDatos.Entities;
using QueMePongo.Dominio.Models;
using System;
using System.Configuration;

namespace QueMePongo.AccesoDatos.Data
{
    public class QueMePongoDbContext : DbContext
    {

        public QueMePongoDbContext() : base()
        {
        }
        public QueMePongoDbContext(DbContextOptions<QueMePongoDbContext> options)
            : base(options)
        {


        }

        public DbSet<PrendaEntity> Prendas { get; set; }
        public DbSet<GuardarropaEntity> Guardarropas { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<EventoEntity> Eventos { get; set; }
        public DbSet<SugerenciaEntity> Sugerencias { get; set; }
        public DbSet<SensibilidadLocalEntity> SensibilidadLocal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\BFNB13019;Database=QueMePongo;Trusted_Connection=True;");


        }
    }
}
