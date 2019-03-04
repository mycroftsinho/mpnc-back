using System.Threading.Tasks;
using core.Gateways;
using dominio.Scopers;
using usecase.Cases.ManterLojas.Input;
using usecase.Cases.ManterLojas.Output;
using usecase.Repositorio.Loja;

namespace usecase.Cases.ManterLojas
{
    public class AlterarDadosDaLoja : ILimiteDeEntrada<EntradaParaAlterarDadosDaLoja>
    {
        private readonly ILojaLeituraRepositorio _leituraRepositorio;
        private readonly ILojaEscritaRepositorio _escritaRepositorio;
        private readonly ILimiteDeSaida<SaidaDeAlteracaoDeLojas> _outputBoundary;

        public AlterarDadosDaLoja(ILojaLeituraRepositorio leituraRepositorio, ILojaEscritaRepositorio escritaRepositorio, ILimiteDeSaida<SaidaDeAlteracaoDeLojas> outputBoundary)
        {
            _leituraRepositorio = leituraRepositorio;
            _escritaRepositorio = escritaRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaParaAlterarDadosDaLoja entrada)
        {
            var loja = await _leituraRepositorio.BuscarLoja(entrada.Nome);
            if (loja == null)
            {
                _outputBoundary.Popular(new SaidaDeAlteracaoDeLojas(false));
                return;
            }

            loja.AlterarEndereco(entrada.Cep, entrada.Rua, entrada.Bairro, entrada.Numero);
            loja.AlterarDadosBasicos(entrada.Nome, entrada.Email, entrada.Telefone);
            var validacao = loja.Validar();

            if(validacao.IsValid)
            {
                await _escritaRepositorio.AtualizarLoja(loja);
                _outputBoundary.Popular(new SaidaDeAlteracaoDeLojas(true));
                return;
            }
            _outputBoundary.Popular(new SaidaDeAlteracaoDeLojas(false, null, validacao.Errors));
        }
    }
}