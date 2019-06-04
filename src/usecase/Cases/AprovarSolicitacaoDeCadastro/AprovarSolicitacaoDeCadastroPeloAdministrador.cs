using System.Threading.Tasks;
using core.Gateways;
using dominio.Modelo;
using usecase.Cases.AprovarSolicitacaoDeCadastro.Input;
using usecase.Cases.AprovarSolicitacaoDeCadastro.Output;
using usecase.Repositorio.Loja;
using usecase.Repositorio.Usuario;

namespace usecase.Cases.AprovarSolicitacaoDeCadastro
{
    public class AprovarSolicitacaoDeCadastroPeloAdministrador : ILimiteDeEntrada<EntradaDeAprovacaoDeSolicitacao>
    {
        private const string perfil = "Lojista";
        private readonly ILojaLeituraRepositorio _leituraRepositorio;
        private readonly ILojaEscritaRepositorio _escritaRepositorio;
        private readonly IUsuarioEscritaRepositorio _usuarioEscritaRepositorio;
        private readonly ILimiteDeSaida<SaidaDeAprovacaoDeSolicitacao> _outputBoundary;

        public AprovarSolicitacaoDeCadastroPeloAdministrador(ILojaLeituraRepositorio leituraRepositorio, ILojaEscritaRepositorio escritaRepositorio, IUsuarioEscritaRepositorio usuarioEscritaRepositorio, ILimiteDeSaida<SaidaDeAprovacaoDeSolicitacao> outputBoundary)
        {
            _leituraRepositorio = leituraRepositorio;
            _escritaRepositorio = escritaRepositorio;
            _usuarioEscritaRepositorio = usuarioEscritaRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaDeAprovacaoDeSolicitacao entrada)
        {
            var loja = await _leituraRepositorio.BuscarLoja(entrada.Email, entrada.Cnpj);
            if (loja == null)
            {
                _outputBoundary.Popular(new SaidaDeAprovacaoDeSolicitacao(false));
                return;
            }

            loja.AlterarSituacaoCadastral(entrada.IntencaoDeAprovacao);
            await _escritaRepositorio.AtualizarLoja(loja);

            if (entrada.IntencaoDeAprovacao)
            {
                var usuario = new Usuario(loja.Empresa, entrada.Email, entrada.Email, perfil);
                var validacao = usuario.Validar();
                if (validacao.IsValid)
                    await _usuarioEscritaRepositorio.GravarUsuario(usuario);
            }
            else
            {
                await _escritaRepositorio.RemoverLoja(loja);
            }
            _outputBoundary.Popular(new SaidaDeAprovacaoDeSolicitacao(true));
        }
    }
}