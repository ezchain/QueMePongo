namespace QueMePongo.Dominio.Models
{
    public class Prenda
    {
        public int PrendaId { get; set; }
        public int GuardarropaId { get; set; }
        public Categoria Categoria { get; set; }
        public TipoDePrenda Tipo { get; set; }
        public Tela Tela { get; set; }
        public Color ColorPrimario { get; set; }
        public Color? ColorSecundario { get; set; }
    }
}
