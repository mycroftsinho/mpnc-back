using System.Threading.Tasks;
using core.Gateways;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using usecase.Cases.ManterProdutos.Input;
using usecase.Cases.ManterProdutos.Output;

namespace webapi.UseCases.ManterProdutos
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProdutoController : ControllerBase
    {
        private readonly ILimiteDeEntrada<EntradaParaGravarOuAlterarProduto> _inputCadastro;
        private readonly ILimiteDeEntrada<EntradaParaRemoverProduto> _inputRemover;
        private readonly ILimiteDeEntrada<EntradaParaListarProdutos> _inputListagem;
        private readonly Presenter _presenter;

        public ProdutoController(ILimiteDeEntrada<EntradaParaGravarOuAlterarProduto> inputCadastro, ILimiteDeEntrada<EntradaParaRemoverProduto> inputRemover, ILimiteDeEntrada<EntradaParaListarProdutos> inputListagem, ILimiteDeSaida<SaidaDeAlteracoesDeProdutos> presenter)
        {
            _inputCadastro = inputCadastro;
            _inputRemover = inputRemover;
            _inputListagem = inputListagem;
            _presenter = (Presenter)presenter;
        }

        [HttpGet]
        [Route("ListarProdutos")]
        public async Task<IActionResult> ListarProdutos(int lojaId)
        {
            var request = new EntradaParaListarProdutos(0, lojaId);
            await _inputListagem.Executar(request);
            return _presenter.ViewModel;
        }

        [HttpGet]
        [Route("ObterProduto")]
        public async Task<IActionResult> ObterProduto(int id)
        {
            var request = new EntradaParaListarProdutos(id, 0);
            await _inputListagem.Executar(request);
            return _presenter.ViewModel;
        }

        [HttpPost]
        [Route("CadastrarProduto")]
        public async Task<IActionResult> CadastrarProduto([FromBody] CadastroRequest message)
        {
            var request = new EntradaParaGravarOuAlterarProduto(message.ProdutoId, message.Descricao, message.Valor, message.LojaId);
            await _inputCadastro.Executar(request);
            return _presenter.ViewModel;
        }

        [HttpPost]
        [Route("RemoverProduto")]
        public async Task<IActionResult> RemoverProduto([FromBody] RemoverProdutoRequest message)
        {
            var request = new EntradaParaRemoverProduto(message.ProdutoId);
            await _inputRemover.Executar(request);
            return _presenter.ViewModel;
        }
    }
}