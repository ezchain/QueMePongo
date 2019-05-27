namespace QueMePongo.Dominio.Models
{
    public class Prenda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Categoria Categoria { get; set; }
        public Tipo Tipo { get; set; }
        public Tela Tela { get; set; }
        public Color ColorPrimario { get; set; }
        public Color? ColorSecundario { get; set; }
    }
}
