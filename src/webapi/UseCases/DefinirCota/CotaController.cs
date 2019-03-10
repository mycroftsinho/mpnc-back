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
    public class CotaController : Controller
    {
        private readonly ILimiteDeEntrada<EntradaParaDefinicaoDeCota> _inputCadastro;
        private readonly ILimiteDeEntrada<EntradaParaListagemDeCota> _inputListagem;
        private readonly Presenter _presenter;

        public CotaController(ILimiteDeEntrada<EntradaParaDefinicaoDeCota> inputCadastro, ILimiteDeEntrada<EntradaParaListagemDeCota> inputListagem, ILimiteDeSaida<SaidaDeDefinicaoDeCota> presenter)
        {
            _inputCadastro = inputCadastro;
            _inputListagem = inputListagem;
            _presenter = (Presenter)presenter;
        }

        [HttpGet]
        [Route("ListarCotas")]
        public async Task<IActionResult> ListarCotas()
        {
            var request = new EntradaParaListagemDeCota();
            await _inputListagem.Executar(request);
            return _presenter.ViewModel;
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