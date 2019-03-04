using System.Linq;
using System.Threading.Tasks;
using core.Gateways;
using usecase.Cases.ManterProdutos.Input;
using usecase.Cases.ManterProdutos.Output;
using usecase.Repositorio.Produto;

namespace usecase.Cases.ManterProdutos
{
    public class ListarProdutosDaLoja : ILimiteDeEntrada<EntradaParaListarProdutos>
    {
        private readonly IProdutoLeituraRepositorio _leituraRepositorio;
        private readonly ILimiteDeSaida<SaidaDeAlteracoesDeProdutos> _outputBoundary;

        public ListarProdutosDaLoja(IProdutoLeituraRepositorio leituraRepositorio, ILimiteDeSaida<SaidaDeAlteracoesDeProdutos> outputBoundary)
        {
            _leituraRepositorio = leituraRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaParaListarProdutos entrada)
        {
            if (entrada.Id > 0)
            {
                var produto = await _leituraRepositorio.BuscarProdutoPorId(entrada.Id);
                _outputBoundary.Popular(new SaidaDeAlteracoesDeProdutos(true, null, new SaidaDeProduto(produto)));
                return;
            }
            var produtos = await _leituraRepositorio.BuscarProdutosDaLoja(entrada.LojaId);
            _outputBoundary.Popular(new SaidaDeAlteracoesDeProdutos(true, produtos.Select(x => new SaidaDeProduto(x)).ToList()));
        }
    }
}