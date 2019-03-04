using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Contexto;
using dominio.Modelo;
using Microsoft.EntityFrameworkCore;
using usecase.Repositorio.Produto;

namespace data.Repositorio.Produto
{
    public class ProdutoLeituraRepositorio : IProdutoLeituraRepositorio
    {
        private readonly BuscadorContexto _contexto;

        public ProdutoLeituraRepositorio(BuscadorContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<dominio.Modelo.Produto> BuscarProdutoParaAlteracao(int produtoId)
        {
            return await _contexto.Produto.FindAsync(produtoId);
        }

        public async Task<dominio.Modelo.Produto> BuscarProdutoPorId(int produtoId)
        {
            return await _contexto.Produto.AsNoTracking().FirstOrDefaultAsync(x => x.Id == produtoId);
        }

        public async Task<IEnumerable<dominio.Modelo.Produto>> BuscarProdutosDaLoja(int lojaId)
        {
            return await _contexto.Produto.Where(x => x.LojaId == lojaId).ToListAsync();
        }

        public async Task<int> BuscarQuantidadeDeProdutosCadastrados(int lojaId)
        {
            return await _contexto.Produto.CountAsync(x => x.LojaId == lojaId);
        }
    }
}