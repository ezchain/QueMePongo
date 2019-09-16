
using Microsoft.AspNetCore.Http;
using QueMePongo.Dominio.Models;

namespace QueMePongo.Dominio.DTOs
{
    public class PrendaDTO
    {
        public int PrendaId { get; set; }
        public int GuardarropaId { get; set; }
        public Categoria Categoria { get; set; }
        public TipoDePrenda Tipo { get; set; }
        public Tela Tela { get; set; }
        public Color ColorPrimario { get; set; }
        public Color? ColorSecundario { get; set; }
        public IFormFile Imagen { get; set; }
    }
}
