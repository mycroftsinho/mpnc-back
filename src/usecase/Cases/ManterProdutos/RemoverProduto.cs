using core.Gateways;
using System.Threading.Tasks;
using usecase.Repositorio.Produto;
using usecase.Cases.ManterProdutos.Input;
using usecase.Cases.ManterProdutos.Output;

namespace usecase.Cases.ManterProdutos
{
    public class RemoverProduto : ILimiteDeEntrada<EntradaParaRemoverProduto>
    {
        private readonly IProdutoLeituraRepositorio _leituraRepositorio;
        private readonly IProdutoEscritaRepositorio _escritaRepositorio;
        private readonly ILimiteDeSaida<SaidaDeAlteracoesDeProdutos> _outputBoundary;

        public RemoverProduto(IProdutoLeituraRepositorio leituraRepositorio, IProdutoEscritaRepositorio escritaRepositorio, ILimiteDeSaida<SaidaDeAlteracoesDeProdutos> outputBoundary)
        {
            _leituraRepositorio = leituraRepositorio;
            _escritaRepositorio = escritaRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaParaRemoverProduto entrada)
        {
            var produto = await _leituraRepositorio.BuscarProdutoParaAlteracao(entrada.ProdutoId);
            if(produto == null)
            {
                _outputBoundary.Popular(new SaidaDeAlteracoesDeProdutos(false));
                return;
            }
            await _escritaRepositorio.RemoverProduto(produto);
            _outputBoundary.Popular(new SaidaDeAlteracoesDeProdutos(true));
        }
    }
}