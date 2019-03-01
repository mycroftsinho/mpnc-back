using core.Gateways;
using dominio.Modelo;
using System.Threading.Tasks;
using usecase.Repositorio.Loja;
using usecase.Cases.SolicitarCadastro.Input;
using usecase.Cases.SolicitarCadastro.Output;

namespace usecase.Cases.SolicitarCadastro
{
    public class SolicitarCadastroPelaLoja : ILimiteDeEntrada<EntradaDeSolicitacaoDeCadastro>
    {
        private readonly ILojaLeituraRepositorio _leituraRepositorio;
        private readonly ILojaEscritaRepositorio _escritaRepositorio;
        private readonly ILimiteDeSaida<SaidaDaSolicitacaoDeCadastro> _outputBoundary;

        public SolicitarCadastroPelaLoja(ILojaLeituraRepositorio leituraRepositorio, ILojaEscritaRepositorio escritaRepositorio, ILimiteDeSaida<SaidaDaSolicitacaoDeCadastro> outputBoundary)
        {
            _leituraRepositorio = leituraRepositorio;
            _escritaRepositorio = escritaRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaDeSolicitacaoDeCadastro entrada)
        {
            var loja = new Loja(entrada.Nome, entrada.Email, entrada.Telefone, entrada.Rua, entrada.Numero, entrada.Bairro, entrada.Cep);
            var lojaDuplicada = await _leituraRepositorio.BuscarLoja(loja.Nome);
            if (loja != null)
            {
                _outputBoundary.Popular(new SaidaDaSolicitacaoDeCadastro(false));
                return;
            }

            var validacao = loja.Validar();
            if(!validacao.IsValid)
            {
                _outputBoundary.Popular(new SaidaDaSolicitacaoDeCadastro(false, validacao.Errors));
                return;
            }

            await _escritaRepositorio.GravarLoja(loja);
            _outputBoundary.Popular(new SaidaDaSolicitacaoDeCadastro(true));
        }
    }
}