
using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces.Repositorios;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using QueMePongo.Dominio.Interfaces;
using QueMePongo.AccesoDatos.Repositorios;
using Microsoft.AspNetCore.Http;

namespace QueMePongo.Negocio.Servicios
{
    public class PrendaService : IPrendaService
    {
        private readonly IPrendasRepositorio prendasRepositorio;
        private readonly IImagenHelper imagenHelper;

        public PrendaService(IImagenHelper imagenHelper)
        {
            this.prendasRepositorio = new PrendasRepositorio();
            this.imagenHelper = imagenHelper;
        }

        public void AddPrenda(PrendaDTO prendaDTO, IFormFile imagen)
        {
            var prenda = ToModel(prendaDTO,imagen);

            prendasRepositorio.AddPrenda(prenda);
        }

        public void DeletePrenda(int id)
        {
            prendasRepositorio.DeletePrenda(id);
        }

        public Prenda GetPrenda(int id)
        {
            return prendasRepositorio.GetPrenda(id);
            
        }

        public IEnumerable<Prenda> GetPrendas()
        {
            return prendasRepositorio.GetPrendas().ToList();

        }

        public void UpdatePrenda(Prenda prenda)
        {
            prendasRepositorio.UpdatePrenda(prenda);
        }

        //private PrendaDTO ToDto(Prenda prenda)
        //{
        //    var stream = new MemoryStream(prenda.Imagen);
        //    var imagen = Image.FromStream(stream);


        //    return new PrendaDTO()
        //    {
        //        PrendaId = prenda.PrendaId,
        //        Tipo = prenda.Tipo,
        //        Categoria = prenda.Categoria,
        //        ColorPrimario = prenda.ColorPrimario,
        //        ColorSecundario = prenda.ColorSecundario,
        //        Tela = prenda.Tela,
        //        GuardarropaId = prenda.GuardarropaId,
        //        Imagen = imagen

        //    }
        //}

        private Prenda ToModel(PrendaDTO prendaDTO, IFormFile imagenFile)
        {

            var byteArrayImagen = imagenHelper.ImagenFileToArray(imagenFile);
     
            return new Prenda()
            {
                PrendaId = prendaDTO.PrendaId,
                Categoria = prendaDTO.Categoria,
                ColorPrimario = prendaDTO.ColorPrimario,
                ColorSecundario = prendaDTO.ColorSecundario,
                GuardarropaId = prendaDTO.GuardarropaId,
                Tela = prendaDTO.Tela,
                Tipo = prendaDTO.Tipo,
                Imagen = byteArrayImagen
            };
  
        }
    }
}
