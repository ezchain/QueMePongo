using System.ComponentModel.DataAnnotations;

namespace QueMePongo.Dominio.Models
{
    public class Prenda
    {
        public int PrendaId { get; set; }
        public int GuardarropaId { get; set; }
        public Guardarropa Guardarropa { get; set; }
        [Required]
        public Categoria Categoria { get; set; }
        [Required]
        public Tipo Tipo { get; set; }
        [Required]
        public Tela Tela { get; set; }
        [Required]
        public Color ColorPrimario { get; set; }
        public Color? ColorSecundario { get; set; }
    }
}
