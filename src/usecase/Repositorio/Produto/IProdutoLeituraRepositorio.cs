using System.Collections.Generic;
using System.Threading.Tasks;

namespace usecase.Repositorio.Produto
{
    public interface IProdutoLeituraRepositorio
    {
        Task<IEnumerable<dominio.Modelo.Produto>> BuscarProdutosDaLoja(int lojaId);
        
        Task<dominio.Modelo.Produto> BuscarProdutoParaAlteracao(int produtoId);
        
        Task<dominio.Modelo.Produto> BuscarProdutoPorId(int produtoId);
        
        Task<int> BuscarQuantidadeDeProdutosCadastrados(int lojaId);
    }
}