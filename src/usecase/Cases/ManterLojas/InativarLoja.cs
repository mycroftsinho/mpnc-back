using System.Threading.Tasks;
using core.Gateways;
using usecase.Cases.ManterLojas.Input;
using usecase.Cases.ManterLojas.Output;
using usecase.Repositorio.Loja;

namespace usecase.Cases.ManterLojas
{
    public class InativarLoja : ILimiteDeEntrada<EntradaParaInativarLoja>
    {
        private readonly ILojaLeituraRepositorio _leituraRepositorio;
        private readonly ILojaEscritaRepositorio _escritaRepositorio;
        private readonly ILimiteDeSaida<SaidaDeAlteracaoDeLojas> _outputBoundary;

        public InativarLoja(ILojaLeituraRepositorio leituraRepositorio, ILojaEscritaRepositorio escritaRepositorio, ILimiteDeSaida<SaidaDeAlteracaoDeLojas> outputBoundary)
        {
            _leituraRepositorio = leituraRepositorio;
            _escritaRepositorio = escritaRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaParaInativarLoja entrada)
        {
            var loja = await _leituraRepositorio.BuscarLojaPorId(entrada.LojaId);
            if(loja == null)
            {
                _outputBoundary.Popular(new SaidaDeAlteracaoDeLojas(false));
                return;
            }

            loja.AlterarSituacaoCadastral(entrada.InativarLoja);
            await _escritaRepositorio.AtualizarLoja(loja);
            _outputBoundary.Popular(new SaidaDeAlteracaoDeLojas(true));
        }
    }
}