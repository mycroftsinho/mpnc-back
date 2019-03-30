using core.Gateways;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using usecase.Cases.RealizarLogin.Input;
using usecase.Cases.RealizarLogin.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace webapi.UseCases.RealizarLogin
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly ILimiteDeEntrada<EntradaParaRealizarLogin> _input;
        private readonly Presenter _presenter;

        public AccountController(ILimiteDeEntrada<EntradaParaRealizarLogin> input, ILimiteDeSaida<SaidaDeRealizacaoDeLogin> presenter)
        {
            _input = input;
            _presenter = (Presenter)presenter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LoginRequest message)
        {
            var request = new EntradaParaRealizarLogin(message.Email, message.Senha);
            await _input.Executar(request);
            return _presenter.ViewModel;
        }
    }
}