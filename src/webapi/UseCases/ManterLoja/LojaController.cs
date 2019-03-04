using System.Threading.Tasks;
using core.Gateways;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using usecase.Cases.ManterLojas.Input;
using usecase.Cases.ManterLojas.Output;

namespace webapi.UseCases.ManterLoja
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LojaController : Controller
    {
        private readonly ILimiteDeEntrada<EntradaParaAlterarDadosDaLoja> _inputCadastro;
        private readonly ILimiteDeEntrada<EntradaParaInativaLoja> _inputInativar;
        private readonly ILimiteDeEntrada<EntradaDeListagemDasLojas> _inputListagem;
        private readonly Presenter _presenter;

        public LojaController(ILimiteDeEntrada<EntradaParaAlterarDadosDaLoja> inputCadastro, ILimiteDeEntrada<EntradaParaInativaLoja> inputInativar, ILimiteDeEntrada<EntradaDeListagemDasLojas> inputListagem, ILimiteDeSaida<SaidaDeAlteracaoDeLojas> presenter)
        {
            _inputCadastro = inputCadastro;
            _inputInativar = inputInativar;
            _inputListagem = inputListagem;
            _presenter = (Presenter)presenter;
        }

        [HttpGet]
        [Route("ListarLojas")]
        public async Task<IActionResult> ListarLojas()
        {
            var request = new EntradaDeListagemDasLojas();
            await _inputListagem.Executar(request);
            return _presenter.ViewModel;
        }

        [HttpGet]
        [Route("ObterLoja")]
        public async Task<IActionResult> ObterLoja(int id)
        {
            var request = new EntradaDeListagemDasLojas(id);
            await _inputListagem.Executar(request);
            return _presenter.ViewModel;
        }

        [HttpPost]
        [Route("CadastrarLoja")]
        public async Task<IActionResult> CadastrarLoja([FromBody] CadastroRequest message)
        {
            var request = new EntradaParaAlterarDadosDaLoja(message.Nome, message.Email, message.Telefone, message.Cep, message.Rua, message.Bairro, message.Numero);
            await _inputCadastro.Executar(request);
            return _presenter.ViewModel;
        }

        [HttpPost]
        [Route("RemoverLoja")]
        public async Task<IActionResult> RemoverLoja([FromBody] RemoverLojaRequest message)
        {
            var request = new EntradaParaInativaLoja(message.Id);
            await _inputInativar.Executar(request);
            return _presenter.ViewModel;
        }
    }
}