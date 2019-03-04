using System.Threading.Tasks;
using core.Gateways;
using Microsoft.AspNetCore.Mvc;
using usecase.Cases.AprovarSolicitacaoDeCadastro.Input;
using usecase.Cases.AprovarSolicitacaoDeCadastro.Output;

namespace webapi.UseCases.AprovarSolicitacaoDeCadastro
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly ILimiteDeEntrada<EntradaDeAprovacaoDeSolicitacao> _input;
        private readonly ILimiteDeEntrada<EntradaDeListagemDeSolicitacoes> _inputListagem;
        private readonly ILimiteDeEntrada<EntradaParaObterSolicitacao> _inputConsulta;
        private readonly Presenter _presenter;

        public CadastroController(ILimiteDeEntrada<EntradaDeAprovacaoDeSolicitacao> input, ILimiteDeEntrada<EntradaDeListagemDeSolicitacoes> inputListagem, ILimiteDeEntrada<EntradaParaObterSolicitacao> inputConsulta, ILimiteDeSaida<SaidaDeAprovacaoDeSolicitacao> presenter)
        {
            _input = input;
            _inputListagem = inputListagem;
            _inputConsulta = inputConsulta;
            _presenter = (Presenter)presenter;
        }

        [HttpGet]
        [Route("ListarCadastrosPendentes")]
        public async Task<IActionResult> ListarCadastrosPendentes()
        {
            var request = new EntradaDeListagemDeSolicitacoes();
            await _inputListagem.Executar(request);
            return _presenter.ViewModel;
        }

        [HttpGet]
        [Route("ObterCadastro")]
        public async Task<IActionResult> ObterCadastro(AprovacaoRequest message)
        {
            var request = new EntradaParaObterSolicitacao(message.LojaId, message.Nome);
            await _inputConsulta.Executar(request);
            return _presenter.ViewModel;
        }

        [HttpPost]
        public async Task<IActionResult> SolicitarCadastro([FromBody]AprovacaoRequest message)
        {
            var entrada = new EntradaDeAprovacaoDeSolicitacao(message.LojaId, message.IntencaoDeSolicitacao);
            await _input.Executar(entrada);
            return _presenter.ViewModel;
        }

    }
}