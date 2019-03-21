using dominio.Modelo;

namespace usecase.Cases.RealizarLogin.Output
{
    public class SaidaDeRealizacaoDeLogin
    {
        public SaidaDeRealizacaoDeLogin(bool situacao)
        {
            Situacao = situacao;
        }

        public SaidaDeRealizacaoDeLogin(bool situacao, Login usuario)
        {
            UserName = usuario.UserName;
            AccessKey = usuario.AccessKey;
            Situacao = situacao;
        }

        public string UserName { get; private set; }
        public string AccessKey { get; private set; }
        public bool Situacao { get; private set; }

    }
}