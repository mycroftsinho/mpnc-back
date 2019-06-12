using System.Linq;
using core.Gateways;
using System.Threading.Tasks;
using usecase.Repositorio.Endereco;
using usecase.Cases.ManterEnderecos.Input;
using usecase.Cases.ManterEnderecos.Output;

namespace usecase.Cases.ManterEnderecos
{
    public class BuscarEndereco : ILimiteDeEntrada<EntradaParaBuscarEndereco>
    {
        private readonly IEnderecoLeituraRepositorio repositorioLeitura;
        private readonly ILimiteDeSaida<SaidaParaManterEnderecos> _outputBoundary;

        public BuscarEndereco(IEnderecoLeituraRepositorio repositorioLeitura, ILimiteDeSaida<SaidaParaManterEnderecos> outputBoundary)
        {
            this.repositorioLeitura = repositorioLeitura;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaParaBuscarEndereco entrada)
        {
            if(entrada.LojaId > 0)
            {
                var enderecos = await repositorioLeitura.BuscarEnderecosDaLoja(entrada.LojaId);
                _outputBoundary.Popular(new SaidaParaManterEnderecos(true, enderecos.Select(x => new SaidaDeEndereco(x)).ToList()));
                return;
            }
            var endereco = await repositorioLeitura.BuscarEnderecoPorId(entrada.EnderecoId);
            _outputBoundary.Popular(new SaidaParaManterEnderecos(true, new SaidaDeEndereco(endereco)));
        }
    }
}