using core.Gateways;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using usecase.Cases.DefinirCotas.Input;
using usecase.Cases.DefinirCotas.Output;

namespace webapi.UseCases.DefinirCota
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CotaController : ControllerBase
    {
        private readonly ILimiteDeEntrada<EntradaParaDefinicaoDeCota> _inputCadastro;
        private readonly Presenter _presenter;

        public CotaController(ILimiteDeEntrada<EntradaParaDefinicaoDeCota> inputCadastro, ILimiteDeSaida<SaidaDeDefinicaoDeCota> presenter)
        {
            _inputCadastro = inputCadastro;
            _presenter = (Presenter)presenter;
        }

        [HttpPost]
        [Route("DefinirCota")]
        public async Task<IActionResult> DefinirCota([FromBody] CadastroRequest message)
        {
            var request = new EntradaParaDefinicaoDeCota(message.LojaId, message.Quantidade);
            await _inputCadastro.Executar(request);
            return _presenter.ViewModel;
        }
    }
}