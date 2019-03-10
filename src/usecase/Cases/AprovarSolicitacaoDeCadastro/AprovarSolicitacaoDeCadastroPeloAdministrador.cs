using System.Threading.Tasks;
using core.Gateways;
using usecase.Cases.AprovarSolicitacaoDeCadastro.Input;
using usecase.Cases.AprovarSolicitacaoDeCadastro.Output;
using usecase.Repositorio.Loja;

namespace usecase.Cases.AprovarSolicitacaoDeCadastro
{
    public class AprovarSolicitacaoDeCadastroPeloAdministrador : ILimiteDeEntrada<EntradaDeAprovacaoDeSolicitacao>
    {
        private readonly ILojaLeituraRepositorio _leituraRepositorio;
        private readonly ILojaEscritaRepositorio _escritaRepositorio;
        private readonly ILimiteDeSaida<SaidaDeAprovacaoDeSolicitacao> _outputBoundary;

        public AprovarSolicitacaoDeCadastroPeloAdministrador(ILojaLeituraRepositorio leituraRepositorio, ILojaEscritaRepositorio escritaRepositorio, ILimiteDeSaida<SaidaDeAprovacaoDeSolicitacao> outputBoundary)
        {
            _leituraRepositorio = leituraRepositorio;
            _escritaRepositorio = escritaRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaDeAprovacaoDeSolicitacao entrada)
        {
            var loja = await _leituraRepositorio.BuscarLoja(entrada.Email, entrada.Nome);
            if (loja == null)
            {
                _outputBoundary.Popular(new SaidaDeAprovacaoDeSolicitacao(false));
                return;
            }

            loja.AlterarSituacaoCadastral(entrada.IntencaoDeAprovacao);
            await _escritaRepositorio.AtualizarLoja(loja);
            _outputBoundary.Popular(new SaidaDeAprovacaoDeSolicitacao(true));
        }
    }
}