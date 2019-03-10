namespace usecase.Cases.AprovarSolicitacaoDeCadastro.Input
{
    public class EntradaDeAprovacaoDeSolicitacao
    {
        public EntradaDeAprovacaoDeSolicitacao(string nome, string email, bool intencaoDeAprovacao)
        {
            Nome = nome;
            Email = email;
            IntencaoDeAprovacao = intencaoDeAprovacao;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public bool IntencaoDeAprovacao { get; private set; }
    }
}