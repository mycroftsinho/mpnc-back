using core.Gateways;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using usecase.Cases.ManterEnderecos.Input;
using usecase.Cases.ManterEnderecos.Output;
using System.Threading.Tasks;

namespace webapi.UseCases.ManterEnderecos
{
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EnderecoController : Controller
    {
        private readonly ILimiteDeEntrada<EntradaParaGravarOuAlterarEndereco> _inputCadastro;
        private readonly ILimiteDeEntrada<EntradaParaBuscarEndereco> _inputBusca;
        private readonly ILimiteDeEntrada<EntradaParaRemoverEndereco> _inputRemover;
        private readonly Presenter _presenter;

        public EnderecoController(ILimiteDeSaida<SaidaParaManterEnderecos> presenter, ILimiteDeEntrada<EntradaParaGravarOuAlterarEndereco> inputCadastro, ILimiteDeEntrada<EntradaParaBuscarEndereco> inputBusca, ILimiteDeEntrada<EntradaParaRemoverEndereco> inputRemover)
        {
            _inputCadastro = inputCadastro;
            _inputBusca = inputBusca;
            _inputRemover = inputRemover;
            _presenter = (Presenter)presenter;
        }

        [HttpGet]
        [Route("ListarEnderecos")]
        public async Task<IActionResult> ListarEnderecos(int lojaId)
        {
            var request = new EntradaParaBuscarEndereco(lojaId);
            await _inputBusca.Executar(request);
            return _presenter.ViewModel;
        }

        [HttpGet]
        [Route("ObterEndereco")]
        public async Task<IActionResult> ObterEndereco(int id)
        {
            var request = new EntradaParaBuscarEndereco(0, id);
            await _inputBusca.Executar(request);
            return _presenter.ViewModel;
        }

        [HttpPost]
        [Route("CadastrarLoja")]
        public async Task<IActionResult> CadastrarEndereco([FromBody] CadastroRequest message)
        {
            var request = new EntradaParaGravarOuAlterarEndereco(message.Id, message.LojaId, message.Rua, message.Numero, message.Bairro, message.Cep);
            await _inputCadastro.Executar(request);
            return _presenter.ViewModel;
        }

        [HttpPost]
        [Route("Remover")]
        public async Task<IActionResult> Remover([FromBody] CadastroRequest message)
        {
            var request = new EntradaParaRemoverEndereco(message.Id);
            await _inputRemover.Executar(request);
            return _presenter.ViewModel;
        }

    }
}