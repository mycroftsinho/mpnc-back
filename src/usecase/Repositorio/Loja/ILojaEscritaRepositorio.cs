using dominio.Modelo;
using System.Threading.Tasks;

namespace usecase.Repositorio.Loja
{
    public interface ILojaEscritaRepositorio
    {
        Task GravarLoja(dominio.Modelo.Loja loja);
        Task AtualizarLoja(dominio.Modelo.Loja loja);
    }
}