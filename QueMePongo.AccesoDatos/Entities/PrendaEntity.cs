using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueMePongo.AccesoDatos.Entities
{
    public class PrendaEntity
    {
        [Key]
        public int PrendaId { get; set; }

        [ForeignKey("GuardarropaEntity")]
        public int GuardarropaId { get; set; }
        public GuardarropaEntity Guardarropa { get; set; }

        [ForeignKey("CategoriaEntity")]
        public int CategoriaId { get; set; }
        public CategoriaEntity Categoria { get; set; }

        [ForeignKey("TipoDePrendaEntity")]
        public int TipoDePrendaId { get; set; }
        public TipoDePrendaEntity Tipo { get; set; }

        [ForeignKey("TelaEntity")]
        public int TelaId { get; set; }
        public TelaEntity Tela { get; set; }

        [ForeignKey("ColorEntity")]
        public int ColorPrimarioId { get; set; }
        public ColorEntity ColorPrimario { get; set; }

        [ForeignKey("ColorEntity")]
        public int? ColorSecundarioId { get; set; }
        public ColorEntity ColorSecundario { get; set; }


        public byte[] Imagen { get; set; }
    }
}
