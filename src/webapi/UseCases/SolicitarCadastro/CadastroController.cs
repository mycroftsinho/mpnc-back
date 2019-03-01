using System.Threading.Tasks;
using core.Gateways;
using Microsoft.AspNetCore.Mvc;
using usecase.Cases.SolicitarCadastro.Input;
using usecase.Cases.SolicitarCadastro.Output;

namespace webapi.UseCases.SolicitarCadastro
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly ILimiteDeEntrada<EntradaDeSolicitacaoDeCadastro> _input;
        private readonly Presenter _presenter;

        public CadastroController(ILimiteDeEntrada<EntradaDeSolicitacaoDeCadastro> input, ILimiteDeSaida<SaidaDaSolicitacaoDeCadastro> presenter)
        {
            _input = input;
            _presenter = (Presenter) presenter;
        }

        [HttpPost]
        public async Task<IActionResult> SolicitarCadastro([FromBody]CadastroRequest message)
        {
            var entrada = new EntradaDeSolicitacaoDeCadastro(message.Nome, message.Email, message.Telefone, message.Cep, message.Rua, message.Bairro, message.Numero);
            await _input.Executar(entrada);
            return _presenter.ViewModel;
        }

    }
}