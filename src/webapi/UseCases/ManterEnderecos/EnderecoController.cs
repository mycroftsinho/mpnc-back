using core.Gateways;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using usecase.Cases.ManterEnderecos.Input;
using usecase.Cases.ManterEnderecos.Output;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace webapi.UseCases.ManterEnderecos
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
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
        [Produces("application/json")]
        public async Task<IActionResult> ListarEnderecos(string email)
        {
            var request = new EntradaParaBuscarEndereco(email);
            await _inputBusca.Executar(request);
            return _presenter.ViewModel;
        }

        [HttpGet]
        [Route("ObterEndereco")]
        [Produces("application/json")]
        public async Task<IActionResult> ObterEndereco(int id)
        {
            var request = new EntradaParaBuscarEndereco(0, id);
            await _inputBusca.Executar(request);
            return _presenter.ViewModel;
        }

        [HttpPost]
        [Route("CadastrarEndereco")]
        [Produces("multipart/form-data")]
        public async Task<IActionResult> CadastrarEndereco([FromForm]int id, [FromForm]string email, [FromForm]string telefone, [FromForm]string numero, [FromForm]string cep, [FromForm]string bairro, [FromForm]string rua, [FromForm] IFormFile imagem)
        {
            byte[] arquivo = null;
            string cotenttype = null;
            if (imagem != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imagem.CopyToAsync(memoryStream);
                    arquivo = memoryStream.ToArray();
                    cotenttype = imagem.ContentType;
                }
            }

            var request = new EntradaParaGravarOuAlterarEndereco(id, email, rua, numero, bairro, cep, cotenttype, arquivo);
            await _inputCadastro.Executar(request);
            return _presenter.ViewModel;
        }

        [HttpPost]
        [Route("Remover")]
        [Produces("application/json")]
        public async Task<IActionResult> Remover([FromBody] CadastroRequest message)
        {
            var request = new EntradaParaRemoverEndereco(message.Id);
            await _inputRemover.Executar(request);
            return _presenter.ViewModel;
        }
    }
}