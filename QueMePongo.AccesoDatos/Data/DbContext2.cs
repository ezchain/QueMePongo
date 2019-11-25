using Microsoft.EntityFrameworkCore;
using QueMePongo.AccesoDatos.Entidades;
using QueMePongo.AccesoDatos.Entities;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.AccesoDatos.Data
{
    public class DbContext2 : DbContext
    {
        public DbContext2() : base()
        {

        }
        public DbContext2(DbContextOptions<DbContext2> options)
    : base(options)
        {


        }
        public DbSet<PrendaEntity> Prendas { get; set; }
        public DbSet<GuardarropaEntity> Guardarropas { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<EventoEntity> Eventos { get; set; }
        public DbSet<SugerenciaEntity> Sugerencias { get; set; }
        public DbSet<SensibilidadLocalEntity> SensibilidadLocal { get; set; }
        public DbSet<PrendasSugerenciaEntity> PrendasSugerencia { get; set; }
        public DbSet<GuardarropasUsuariosEntity> GuardarropasUsuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Que.Me.Pongo;Trusted_Connection=True;");

            }
        }
    }
}