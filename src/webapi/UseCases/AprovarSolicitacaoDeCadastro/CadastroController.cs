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
        private readonly Presenter _presenter;

        public CadastroController(ILimiteDeEntrada<EntradaDeAprovacaoDeSolicitacao> input, ILimiteDeSaida<SaidaDeAprovacaoDeSolicitacao> presenter)
        {
            _input = input;
            _presenter = (Presenter) presenter;
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