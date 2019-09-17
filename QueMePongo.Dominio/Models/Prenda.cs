namespace QueMePongo.Dominio.Models
{
    public class Prenda
    {
        public int PrendaId { get; set; }
        public int GuardarropaId { get; set; }
        public int Categoria { get; set; }
        public TipoDePrenda Tipo { get; set; }
        public int Tela { get; set; }
        public int ColorPrimario { get; set; }
        public int? ColorSecundario { get; set; }
        public byte[] Imagen { get; set; }

    }
}
