using QueMePongo.Dominio.DTOs;

namespace QueMePongo.Dominio.Models
{
    public class Sugerencia
    {
        public int SugerenciaId { get; set; }
        public Atuendo Atuendo { get; set; }
        public bool Aceptada { get; set; }
        public int UsuarioId { get; set; }
        public double CalorTotal { get; set; }

        public Sugerencia()
        {

        }
        public Sugerencia(Atuendo atuendo)
        {
            Atuendo = atuendo;
            CalorTotal = atuendo.CalorTotal();
        }
    }
}
