using System.Threading.Tasks;
using data.Contexto;
using dominio.Modelo;
using usecase.Repositorio.Produto;

namespace data.Repositorio.Produto
{
    public class ProdutoEscritaRepositorio : IProdutoEscritaRepositorio
    {
        private readonly BuscadorContexto _contexto;

        public ProdutoEscritaRepositorio(BuscadorContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task AtualizarProduto(dominio.Modelo.Produto produto)
        {
            _contexto.Update(produto);
            await _contexto.SaveChangesAsync();
        }

        public async Task RemoverProduto(dominio.Modelo.Produto produto)
        {
            _contexto.Remove(produto);
            await _contexto.SaveChangesAsync();
        }
    }
}