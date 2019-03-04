using System.Threading.Tasks;
using dominio.Modelo;

namespace usecase.Repositorio.Produto
{
    public interface IProdutoEscritaRepositorio
    {
        Task AtualizarProduto(dominio.Modelo.Produto produto);
        Task RemoverProduto(dominio.Modelo.Produto produto);
    }
}