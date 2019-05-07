using Datos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Configuraciones
{
    public class UsuarioConfiguracion
    {
        public UsuarioConfiguracion(EntityTypeBuilder<Usuario> typeBuilder)
        {
            typeBuilder.ToTable("Usuarios");
            typeBuilder.HasKey(usuario => usuario.Username);
            typeBuilder.Property(usuario => usuario.Password);
            typeBuilder.Property<Guardarropa[]>(usuario => usuario.Guardarropas);
           
        }
    }
}
