namespace Datos.Entidades
{
    public class Prenda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public short Categoria { get; set; } //Enum
        public short Tipo { get; set; } //Enum
        public short Tela { get; set; } //Enum
        public short ColorPrimario { get; set; } //por ahora Enum...
        public short? ColorSecundario { get; set; } //por ahora Enum....
    }
}
