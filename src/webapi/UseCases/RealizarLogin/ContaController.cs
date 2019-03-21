using core.Gateways;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using usecase.Cases.RealizarLogin.Input;
using usecase.Cases.RealizarLogin.Output;
using Microsoft.AspNetCore.Authorization;

namespace webapi.UseCases.RealizarLogin
{
    [Route("api/[controller]")]
    public class ContaController : Controller
    {
        private readonly ILimiteDeEntrada<EntradaParaRealizarLogin> _input;
        private readonly Presenter _presenter;

        public ContaController(ILimiteDeEntrada<EntradaParaRealizarLogin> input, ILimiteDeSaida<SaidaDeRealizacaoDeLogin> presenter)
        {
            _input = input;
            _presenter = (Presenter)presenter;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginRequest message)
        {
            var request = new EntradaParaRealizarLogin(message.Username, message.AccessKey);
            await _input.Executar(request);
            return _presenter.ViewModel;
        }
    }
}