using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces.Repositorios;
using QueMePongo.Dominio.Interfaces.Servicios;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace QueMePongo.Negocio.Servicios
{
    public class PrendaService : IPrendaService
    {
        private readonly IPrendasRepositorio prendasRepositorio;

        public PrendaService(IPrendasRepositorio prendasRepositorio)
        {
            this.prendasRepositorio = prendasRepositorio;
        }

        public void AddPrenda(PrendaDTO prendaDTO)
        {
            var prenda = ToModel(prendaDTO);

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
        //        return new PrendaDTO()
        //        {
        //            PrendaId = prenda.PrendaId,
        //            Tipo = prenda.Tipo,
        //            Categoria = prenda.Categoria,
        //            ColorPrimario = prenda.ColorPrimario,
        //            ColorSecundario = prenda.ColorSecundario,
        //            Tela = prenda.Tela,
        //            GuardarropaId = prenda.GuardarropaId,

        //        }
        //}

        private Prenda ToModel(PrendaDTO prendaDTO)
        {

        }
    }
}
