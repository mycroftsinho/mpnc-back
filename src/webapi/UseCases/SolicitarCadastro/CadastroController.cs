using System.Threading.Tasks;
using core.Gateways;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using usecase.Cases.SolicitarCadastro.Input;
using usecase.Cases.SolicitarCadastro.Output;

namespace webapi.UseCases.SolicitarCadastro
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CadastroController : ControllerBase
    {
        private readonly ILimiteDeEntrada<EntradaDeSolicitacaoDeCadastro> _input;
        private readonly Presenter _presenter;

        public CadastroController(ILimiteDeEntrada<EntradaDeSolicitacaoDeCadastro> input, ILimiteDeSaida<SaidaDaSolicitacaoDeCadastro> presenter)
        {
            _input = input;
            _presenter = (Presenter)presenter;
        }

        [HttpPost]
        [Route("SolicitarCadastro")]
        public async Task<IActionResult> SolicitarCadastro([FromBody]CadastroRequest message)
        {
            var entrada = new EntradaDeSolicitacaoDeCadastro(message.Nome, message.Email, message.Telefone, message.Cnpj, message.Empresa);
            await _input.Executar(entrada);
            return _presenter.ViewModel;
        }

    }
}