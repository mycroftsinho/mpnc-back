using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Gateways;
using dominio.Modelo;
using usecase.Cases.AprovarSolicitacaoDeCadastro.Input;
using usecase.Cases.AprovarSolicitacaoDeCadastro.Output;
using usecase.Repositorio.Loja;

namespace usecase.Cases.AprovarSolicitacaoDeCadastro
{
    public class ListagemDeSolicitacaoDeCadastro : ILimiteDeEntrada<EntradaDeListagemDeSolicitacoes>
    {
        private readonly ILojaLeituraRepositorio _leituraRepositorio;
        private readonly ILimiteDeSaida<SaidaDeAprovacaoDeSolicitacao> _outputBoundary;

        public ListagemDeSolicitacaoDeCadastro(ILojaLeituraRepositorio leituraRepositorio, ILimiteDeSaida<SaidaDeAprovacaoDeSolicitacao> outputBoundary)
        {
            _leituraRepositorio = leituraRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaDeListagemDeSolicitacoes entrada)
        {
            var lista = await _leituraRepositorio.BuscarLojasComCadastrosPendentes();
            _outputBoundary.Popular(new SaidaDeAprovacaoDeSolicitacao(true, lista.Select(x => new SaidaDeLojas(x)).ToList()));

        }
    }
}