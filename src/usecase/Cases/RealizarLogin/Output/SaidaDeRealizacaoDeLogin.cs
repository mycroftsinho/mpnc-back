using dominio.Modelo;

namespace usecase.Cases.RealizarLogin.Output
{
    public class SaidaDeRealizacaoDeLogin
    {
        public SaidaDeRealizacaoDeLogin(bool situacao)
        {
            Situacao = situacao;
        }

        public SaidaDeRealizacaoDeLogin(bool situacao, Usuario usuario)
        {
            AccessKey = usuario.Password;
            Situacao = situacao;
            Usuario = new DadosDoUsuario(usuario.Id, usuario.Nome, "Administrador");
        }

        public string AccessKey { get; private set; }

        public bool Situacao { get; private set; }

        public DadosDoUsuario Usuario { get; private set; }

    }
}