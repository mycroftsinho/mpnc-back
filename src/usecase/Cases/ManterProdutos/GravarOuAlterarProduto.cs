using System.Threading.Tasks;
using core.Gateways;
using dominio.Modelo;
using usecase.Cases.ManterProdutos.Input;
using usecase.Cases.ManterProdutos.Output;
using usecase.Repositorio.Cota;
using usecase.Repositorio.Produto;

namespace usecase.Cases.ManterProdutos
{
    public class GravarOuAlterarProduto : ILimiteDeEntrada<EntradaParaGravarOuAlterarProduto>
    {
        private readonly IProdutoLeituraRepositorio _leituraRepositorio;
        private readonly IProdutoEscritaRepositorio _escritaRepositorio;
        private readonly ICotaLeituraRepositorio _leituraCotaRepositorio;
        private readonly ILimiteDeSaida<SaidaDeAlteracoesDeProdutos> _outputBoundary;

        public GravarOuAlterarProduto(IProdutoLeituraRepositorio leituraRepositorio, IProdutoEscritaRepositorio escritaRepositorio, ICotaLeituraRepositorio leituraCotaRepositorio, ILimiteDeSaida<SaidaDeAlteracoesDeProdutos> outputBoundary)
        {
            _leituraRepositorio = leituraRepositorio;
            _escritaRepositorio = escritaRepositorio;
            _leituraCotaRepositorio = leituraCotaRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaParaGravarOuAlterarProduto entrada)
        {
            if (entrada.ProdutoId > 0)
            {
                var produtoExistente = await _leituraRepositorio.BuscarProdutoParaAlteracao(entrada.ProdutoId);
                produtoExistente.DefinirInformacoes(entrada.Descricao, entrada.Valor, entrada.LojaId);

                var validacaoProduto = produtoExistente.Validar();
                if (validacaoProduto.IsValid)
                {
                    await _escritaRepositorio.AtualizarProduto(produtoExistente);
                    _outputBoundary.Popular(new SaidaDeAlteracoesDeProdutos(true));
                    return;
                }
                _outputBoundary.Popular(new SaidaDeAlteracoesDeProdutos(false, null, null, validacaoProduto.Errors));
                return;
            }

            var cotaDaLoja = await _leituraCotaRepositorio.BuscarCotaDaLoja(entrada.LojaId);
            var quantidadeDeProdutosDaLoja = await _leituraRepositorio.BuscarQuantidadeDeProdutosCadastrados(entrada.LojaId);

            if (quantidadeDeProdutosDaLoja >= cotaDaLoja.Quantidade)
            {
                _outputBoundary.Popular(new SaidaDeAlteracoesDeProdutos(false));
                return;
            }

            var produto = new Produto(entrada.LojaId, entrada.Descricao, entrada.Valor);
            var validacao = produto.Validar();
            if (validacao.IsValid)
            {
                await _escritaRepositorio.AtualizarProduto(produto);
                _outputBoundary.Popular(new SaidaDeAlteracoesDeProdutos(true));
                return;
            }
            _outputBoundary.Popular(new SaidaDeAlteracoesDeProdutos(false, null, null, validacao.Errors));
            return;
        }
    }
}