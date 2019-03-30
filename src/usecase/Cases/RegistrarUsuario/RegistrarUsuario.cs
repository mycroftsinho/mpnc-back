using System.Threading.Tasks;
using core.Gateways;
using dominio.Modelo;
using usecase.Cases.RegistrarUsuario.Input;
using usecase.Cases.RegistrarUsuario.Output;
using usecase.Repositorio.Usuario;

namespace usecase.Cases.RegistrarUsuario
{
    public class RegistrarUsuario : ILimiteDeEntrada<EntradaParaRegistrarUsuario>
    {
        private readonly IUsuarioLeituraRepositorio _leituraRepositorio;
        private readonly IUsuarioEscritaRepositorio _escritaRepositorio;
        private readonly ILimiteDeSaida<SaidaParaRegistrarUsuario> _outputBoundary;

        public RegistrarUsuario(IUsuarioLeituraRepositorio leituraRepositorio, IUsuarioEscritaRepositorio escritaRepositorio, ILimiteDeSaida<SaidaParaRegistrarUsuario> outputBoundary)
        {
            _leituraRepositorio = leituraRepositorio;
            _escritaRepositorio = escritaRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaParaRegistrarUsuario entrada)
        {
            var usuario = await _leituraRepositorio.BuscarUsuarioPorEmail(entrada.Email);
            if (usuario != null)
            {
                _outputBoundary.Popular(new SaidaParaRegistrarUsuario(false));
                return;
            }

            usuario = new Usuario(entrada.Nome, entrada.Email, entrada.Senha);
            var validacao = usuario.Validar();
            if (!validacao.IsValid)
            {
                _outputBoundary.Popular(new SaidaParaRegistrarUsuario(false, validacao.Errors));
                return;
            }

            await _escritaRepositorio.GravarUsuario(usuario);
            _outputBoundary.Popular(new SaidaParaRegistrarUsuario(true));
        }
    }
}