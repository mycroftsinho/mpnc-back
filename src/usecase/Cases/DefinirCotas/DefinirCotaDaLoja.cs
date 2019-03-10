using System.Threading.Tasks;
using core.Gateways;
using dominio.Modelo;
using usecase.Cases.DefinirCotas.Input;
using usecase.Cases.DefinirCotas.Output;
using usecase.Repositorio.Cota;

namespace usecase.Cases.DefinirCotas
{
    public class DefinirCotaDaLoja : ILimiteDeEntrada<EntradaParaDefinicaoDeCota>
    {
        private readonly ICotaLeituraRepositorio _leituraRepositorio;
        private readonly ICotaEscritaRepositorio _escritaRepositorio;
        private readonly ILimiteDeSaida<SaidaDeDefinicaoDeCota> _outputBoundary;

        public DefinirCotaDaLoja(ICotaLeituraRepositorio leituraRepositorio, ICotaEscritaRepositorio escritaRepositorio, ILimiteDeSaida<SaidaDeDefinicaoDeCota> outputBoundary)
        {
            _leituraRepositorio = leituraRepositorio;
            _escritaRepositorio = escritaRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaParaDefinicaoDeCota entrada)
        {
            var cotaDaLoja = await _leituraRepositorio.BuscarCotaDaLoja(entrada.LojaId);
            if (cotaDaLoja == null)
            {
                cotaDaLoja = new Cota(entrada.LojaId, entrada.Quantidade);
                var validacao = cotaDaLoja.Validar();
                if (validacao.IsValid)
                {
                    await _escritaRepositorio.GravarCota(cotaDaLoja);
                    _outputBoundary.Popular(new SaidaDeDefinicaoDeCota(true));
                    return;
                }
                _outputBoundary.Popular(new SaidaDeDefinicaoDeCota(true));
                return;
            }

            cotaDaLoja.DefinirQuantidadeDeCota(entrada.Quantidade);
            await _escritaRepositorio.AtualizarCota(cotaDaLoja);
            _outputBoundary.Popular(new SaidaDeDefinicaoDeCota(true));
        }
    }
}