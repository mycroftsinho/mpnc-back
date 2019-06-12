using System.Threading.Tasks;
using core.Gateways;
using dominio.Modelo;
using usecase.Cases.ManterEnderecos.Input;
using usecase.Cases.ManterEnderecos.Output;
using usecase.Repositorio.Endereco;

namespace usecase.Cases.ManterEnderecos
{
    public class GravarOuAlterarEndereco : ILimiteDeEntrada<EntradaParaGravarOuAlterarEndereco>
    {
        private readonly IEnderecoLeituraRepositorio leituraRepositorio;
        private readonly IEnderecoEscritaRepositorio escritaRepositorio;
        private readonly ILimiteDeSaida<SaidaParaManterEnderecos> _outputBoundary;

        public GravarOuAlterarEndereco(IEnderecoLeituraRepositorio leituraRepositorio, IEnderecoEscritaRepositorio escritaRepositorio, ILimiteDeSaida<SaidaParaManterEnderecos> outputBoundary)
        {
            this.leituraRepositorio = leituraRepositorio;
            this.escritaRepositorio = escritaRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaParaGravarOuAlterarEndereco entrada)
        {
            if (entrada.Id > 0)
            {
                var endereco = await leituraRepositorio.BuscarEnderecoPorId(entrada.Id);
                endereco.AlterarBairro(entrada.Bairro);
                endereco.AlterarNumero(entrada.Numero);
                endereco.AlterarRua(entrada.Rua);
                endereco.AlterarCep(entrada.Cep);

                var validacao = endereco.Validar();
                if (validacao.IsValid)
                {
                    await escritaRepositorio.Atualizar(endereco);
                    _outputBoundary.Popular(new SaidaParaManterEnderecos(true));
                    return;
                }

                _outputBoundary.Popular(new SaidaParaManterEnderecos(false, validacao.Errors));
                return;
            }

            var novoEndereco = new Endereco(entrada.LojaId, entrada.Rua, entrada.Numero, entrada.Bairro, entrada.Cep);

            var resultado = novoEndereco.Validar();
            if (resultado.IsValid)
            {
                await escritaRepositorio.Gravar(novoEndereco);
                _outputBoundary.Popular(new SaidaParaManterEnderecos(true));
                return;
            }

            _outputBoundary.Popular(new SaidaParaManterEnderecos(false, resultado.Errors));
            return;
        }
    }
}