using System.Threading.Tasks;
using dominio.Modelo;

namespace usecase.Repositorio.Usuario
{
    public interface IUsuarioEscritaRepositorio
    {
        Task GravarUsuario(dominio.Modelo.Usuario usuario);
    }
}