using System.Threading.Tasks;
using core.Gateways;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using usecase.Cases.RegistrarUsuario.Input;
using usecase.Cases.RegistrarUsuario.Output;

namespace webapi.UseCases.RegistrarUsuario
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly ILimiteDeEntrada<EntradaParaRegistrarUsuario> _input;
        private readonly Presenter _presenter;

        public AccountController(ILimiteDeEntrada<EntradaParaRegistrarUsuario> input, ILimiteDeSaida<SaidaParaRegistrarUsuario> presenter)
        {
            _input = input;
            _presenter = (Presenter) presenter;
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody]CadastroRequest message)
        {
            var entrada = new EntradaParaRegistrarUsuario(message.UserName, message.Email, message.Password);
            await _input.Executar(entrada);
            return _presenter.ViewModel;
        }

    }
}