using System.Threading.Tasks;
using core.Gateways;
using usecase.Cases.ManterProdutos.Input;
using usecase.Cases.ManterProdutos.Output;
using usecase.Repositorio.Produto;

namespace usecase.Cases.ManterProdutos
{
    public class ObterProduto : ILimiteDeEntrada<EntradaParaObterProduto>
    {
        private readonly IProdutoLeituraRepositorio _leituraRepositorio;
        
        private readonly ILimiteDeSaida<SaidaDeAlteracoesDeProdutos> _outputBoundary;

        public ObterProduto(IProdutoLeituraRepositorio leituraRepositorio, ILimiteDeSaida<SaidaDeAlteracoesDeProdutos> outputBoundary)
        {
            _leituraRepositorio = leituraRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaParaObterProduto entrada)
        {
            var produto = await _leituraRepositorio.BuscarProdutoPorId(entrada.ProdutoId);
            if(produto == null)
            {
                _outputBoundary.Popular(new SaidaDeAlteracoesDeProdutos(false));
                return;
            }
            _outputBoundary.Popular(new SaidaDeAlteracoesDeProdutos(false, null, new SaidaDeProduto(produto)));
        }
    }
}