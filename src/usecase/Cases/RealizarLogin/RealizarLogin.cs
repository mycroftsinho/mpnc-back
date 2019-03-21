using System.Threading.Tasks;
using core.Gateways;
using usecase.Cases.RealizarLogin.Input;
using usecase.Cases.RealizarLogin.Output;
using usecase.Repositorio.Usuario;

namespace usecase.Cases.RealizarLogin
{
    public class RealizarLogin : ILimiteDeEntrada<EntradaParaRealizarLogin>
    {
        private readonly IUsuarioLeituraRepositorio _leituraRepositorio;
        private readonly ILimiteDeSaida<SaidaDeRealizacaoDeLogin> _outputBoundary;

        public RealizarLogin(IUsuarioLeituraRepositorio leituraRepositorio, ILimiteDeSaida<SaidaDeRealizacaoDeLogin> outputBoundary)
        {
            _leituraRepositorio = leituraRepositorio;
            _outputBoundary = outputBoundary;
        }

        public async Task Executar(EntradaParaRealizarLogin entrada)
        {
            var usuario = await _leituraRepositorio.BuscarUsuario(entrada.UserName, entrada.AccessKey);
            if (usuario != null)
            {
                _outputBoundary.Popular(new SaidaDeRealizacaoDeLogin(true, usuario));
                return;
            }
            _outputBoundary.Popular(new SaidaDeRealizacaoDeLogin(false));
        }
    }
}