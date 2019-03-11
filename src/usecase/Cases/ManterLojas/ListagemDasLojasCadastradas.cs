using System.Linq;
using System.Threading.Tasks;
using core.Gateways;
using usecase.Cases.ManterLojas.Input;
using usecase.Cases.ManterLojas.Output;
using usecase.Repositorio.Loja;

namespace usecase.Cases.ManterLojas
{
    public class ListagemDasLojasCadastradas : ILimiteDeEntrada<EntradaDeListagemDasLojas>
    {
        private readonly ILojaLeituraRepositorio _leituraRepositorio;
        private readonly ILimiteDeSaida<SaidaDeAlteracaoDeLojas> _outputBoundary;

        public ListagemDasLojasCadastradas(ILojaLeituraRepositorio leituraRepositorio, ILimiteDeSaida<SaidaDeAlteracaoDeLojas> outputBoundary)
        {
            _leituraRepositorio = leituraRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaDeListagemDasLojas entrada)
        {
            if (entrada.Id > 0)
            {
                var loja = await _leituraRepositorio.BuscarLojaPorId(entrada.Id.Value);
                if (loja != null)
                {
                    _outputBoundary.Popular(new SaidaDeAlteracaoDeLojas(true, null, new SaidaDeLoja(loja)));
                    return;
                }
                _outputBoundary.Popular(new SaidaDeAlteracaoDeLojas(false));
                return;
            }
            var lojas = await _leituraRepositorio.BuscarLojasCadastradas();
            _outputBoundary.Popular(new SaidaDeAlteracaoDeLojas(true, lojas.Select(x => new SaidaDeLoja(x)).ToList()));
        }
    }
}