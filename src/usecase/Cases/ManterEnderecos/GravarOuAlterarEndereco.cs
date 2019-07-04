using System.Threading.Tasks;
using core.Gateways;
using dominio.Modelo;
using usecase.Cases.ManterEnderecos.Input;
using usecase.Cases.ManterEnderecos.Output;
using usecase.Repositorio.Endereco;
using usecase.Repositorio.Loja;

namespace usecase.Cases.ManterEnderecos
{
    public class GravarOuAlterarEndereco : ILimiteDeEntrada<EntradaParaGravarOuAlterarEndereco>
    {
        private readonly ILojaLeituraRepositorio lojaLeituraRepositorio;
        private readonly IEnderecoLeituraRepositorio leituraRepositorio;
        private readonly IEnderecoEscritaRepositorio escritaRepositorio;
        private readonly ILimiteDeSaida<SaidaParaManterEnderecos> _outputBoundary;

        public GravarOuAlterarEndereco(IEnderecoLeituraRepositorio leituraRepositorio, IEnderecoEscritaRepositorio escritaRepositorio, ILimiteDeSaida<SaidaParaManterEnderecos> outputBoundary, ILojaLeituraRepositorio lojaLeituraRepositorio)
        {
            this.lojaLeituraRepositorio = lojaLeituraRepositorio;
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
                endereco.AlterarImagem(entrada.Imagem, entrada.ContentType);

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

            var loja = await lojaLeituraRepositorio.BuscarLojaPorEmail(entrada.Email);
            if(loja == null)
            {
                _outputBoundary.Popular(new SaidaParaManterEnderecos(false));
                return;
            }
            var novoEndereco = new Endereco(loja.Id, entrada.Rua, entrada.Numero, entrada.Bairro, entrada.Cep, entrada.ContentType, entrada.Imagem);

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