using System.Threading.Tasks;
using dominio.Modelo;

namespace usecase.Repositorio.Usuario
{
    public interface IUsuarioLeituraRepositorio
    {
        Task<dominio.Modelo.Usuario> BuscarUsuario(string userName, string password);
        
        Task<dominio.Modelo.Usuario> BuscarUsuarioPorEmail(string email);
    }
}