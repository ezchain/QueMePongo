using Microsoft.EntityFrameworkCore;
using QueMePongo.AccesoDatos.Entidades;
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
        public DbSet<PrendaEntity> Prendas { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new PrendaConfiguracion());
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(BFNB13019)\\BFNB13019;Database=QueMePongo;Trusted_Connection=True;");
            

        }
    }
}