using System.Threading.Tasks;
using core.Gateways;
using usecase.Cases.ManterEnderecos.Input;
using usecase.Cases.ManterEnderecos.Output;
using usecase.Repositorio.Endereco;

namespace usecase.Cases.ManterEnderecos
{
    public class RemoverEndereco : ILimiteDeEntrada<EntradaParaRemoverEndereco>
    {
        private readonly IEnderecoLeituraRepositorio repositorioLeitura;
        private readonly IEnderecoEscritaRepositorio repositorioEscrita;
        private readonly ILimiteDeSaida<SaidaParaManterEnderecos> _outputBoundary;

        public RemoverEndereco(IEnderecoLeituraRepositorio repositorioLeitura, IEnderecoEscritaRepositorio repositorioEscrita, ILimiteDeSaida<SaidaParaManterEnderecos> outputBoundary)
        {
            this.repositorioLeitura = repositorioLeitura;
            this.repositorioEscrita = repositorioEscrita;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaParaRemoverEndereco entrada)
        {
            if(entrada.EnderecoId > 0)
            {
                var endereco = await repositorioLeitura.BuscarEnderecoPorId(entrada.EnderecoId);
                if(endereco != null)
                {
                    await repositorioEscrita.Remover(endereco);
                    _outputBoundary.Popular(new SaidaParaManterEnderecos(true));
                    return;
                }
            }
            _outputBoundary.Popular(new SaidaParaManterEnderecos(false));
        }
    }
}