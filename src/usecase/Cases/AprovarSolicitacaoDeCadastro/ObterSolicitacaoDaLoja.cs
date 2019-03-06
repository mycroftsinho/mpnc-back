using System.Threading.Tasks;
using core.Gateways;
using usecase.Cases.AprovarSolicitacaoDeCadastro.Input;
using usecase.Cases.AprovarSolicitacaoDeCadastro.Output;
using usecase.Repositorio.Loja;

namespace usecase.Cases.AprovarSolicitacaoDeCadastro
{
    public class ObterSolicitacaoDaLoja : ILimiteDeEntrada<EntradaParaObterSolicitacao>
    {

        private readonly ILojaLeituraRepositorio _leituraRepositorio;
        private readonly ILimiteDeSaida<SaidaDeAprovacaoDeSolicitacao> _outputBoundary;

        public ObterSolicitacaoDaLoja(ILojaLeituraRepositorio leituraRepositorio, ILimiteDeSaida<SaidaDeAprovacaoDeSolicitacao> outputBoundary)
        {
            _leituraRepositorio = leituraRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaParaObterSolicitacao entrada)
        {
            var motorista = await _leituraRepositorio.BuscarLoja(entrada.Email, entrada.Nome);

            if (motorista != null)
                _outputBoundary.Popular(new SaidaDeAprovacaoDeSolicitacao(true, null, new SaidaDeLojas(motorista)));
            else
                _outputBoundary.Popular(new SaidaDeAprovacaoDeSolicitacao(false));
        }
    }
}