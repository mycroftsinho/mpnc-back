using System.Threading.Tasks;
using dominio.Modelo;

namespace usecase.Repositorio.Usuario
{
    public interface IUsuarioLeituraRepositorio
    {
        Task<Login> BuscarUsuario(string userName, string accessKey);
    }
}