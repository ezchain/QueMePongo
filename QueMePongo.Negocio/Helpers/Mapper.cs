using QueMePongo.AccesoDatos.Entities;
using QueMePongo.Dominio.Models;
using System.Collections.Generic;

namespace QueMePongo.Negocio.Helpers
{
    public class Mapper
    {

        public Ubicacion MapEntityToUbicacion(UbicacionEntity ubicacion)
        {
            return new Ubicacion()
            {
                Latitud = ubicacion.Latitud,
                Longitud = ubicacion.Longitud
            };
        }

        public Guardarropa MapEntityToGuardarropa(GuardarropaEntity guardarropa)
        {
            var prendas = new List<Prenda>();
            foreach(var prenda in guardarropa.Prendas)
            {
                prendas.Add(MapEntityToPrenda(prenda));
            }
            return new Guardarropa()
            {
                GuardarropaId = guardarropa.GuardarropaId,
                Prendas = prendas,
                PrendasMaximas = guardarropa.PrendasMaximas,
                Usuarios = guardarropa.Usuarios
            };
        }

        public Prenda MapEntityToPrenda(PrendaEntity prenda)
        {
            return new Prenda()
            {
                PrendaId = prenda.PrendaId,
                Categoria = prenda.Categoria.CategoriaId,
                ColorPrimario = prenda.ColorPrimario.ColorId,
                ColorSecundario = prenda.ColorSecundario.ColorId,
                GuardarropaId = prenda.GuardarropaId,
                Imagen = prenda.Imagen,
                Tela = prenda.Tela.TelaId,
                Tipo = MapEntityToTipoDePrenda(prenda.Tipo)
            };
        }

        public TipoDePrenda MapEntityToTipoDePrenda(TipoDePrendaEntity tipo)
        {
            return new TipoDePrenda()
            {
                Formalidad = tipo.Formalidad,
                Nivel = tipo.Nivel,
                Posicion = tipo.Posicion,
                Temperatura = tipo.Temperatura
            };
        }

        public Usuario MapEntityToUsuario(UsuarioEntity usuario)
        {
            var guardarropas = new List<Guardarropa>();
            foreach(var guardarropa in usuario.Guardarropas)
            {
                guardarropas.Add(MapEntityToGuardarropa(guardarropa));
            }

            return new Usuario()
            {
                UsuarioId = usuario.UsuarioId,
                Guardarropas = guardarropas,
                Mail = usuario.Mail,
                Password = usuario.Password,
                Sensibilidad = new SensibilidadAcalorado(), //HARDCODE
                TipoUsuario = new UsuarioGratuito(),
                Username = usuario.Username
            };
        }





    }
}
