using QueMePongo.AccesoDatos.Repositorios.Interfaces;
using QueMePongo.Dominio.Interfaces;

namespace QueMePongo.Dominio.Models
{
    public class UsuarioPremium : ITipoUsuario
    {
        public void AgregarPrenda(int idGuardarropa, Guardarropa guardarropa, Prenda prenda, IGuardarropaRepositorio guardarropaRepo)
        {
            guardarropaRepo.AgregarPrenda(idGuardarropa, prenda);
        }
    }
}
