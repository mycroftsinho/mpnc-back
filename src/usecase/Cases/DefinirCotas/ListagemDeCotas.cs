using System.Linq;
using System.Threading.Tasks;
using core.Gateways;
using usecase.Cases.DefinirCotas.Input;
using usecase.Cases.DefinirCotas.Output;
using usecase.Repositorio.Cota;
using usecase.Repositorio.Loja;

namespace usecase.Cases.DefinirCotas
{
    public class ListagemDeCotas : ILimiteDeEntrada<EntradaParaListagemDeCota>
    {
        private readonly ILojaLeituraRepositorio _leituraRepositorio;
        private readonly ILimiteDeSaida<SaidaDeDefinicaoDeCota> _outputBoundary;

        public ListagemDeCotas(ILojaLeituraRepositorio leituraRepositorio, ILimiteDeSaida<SaidaDeDefinicaoDeCota> outputBoundary)
        {
            _leituraRepositorio = leituraRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaParaListagemDeCota entrada)
        {
            var lojas = await _leituraRepositorio.BuscarLojasAtivas();
            _outputBoundary.Popular(new SaidaDeDefinicaoDeCota(true, lojas?.Select(x => new SaidaDeCota(x.Id, x.Cota?.Quantidade,x.NomeDaLoja, x.Email,x.Telefone)).ToList()));
        }
    }
}