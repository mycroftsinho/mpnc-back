namespace usecase.Cases.AprovarSolicitacaoDeCadastro.Input
{
    public class EntradaDeAprovacaoDeSolicitacao
    {
        public EntradaDeAprovacaoDeSolicitacao(string cnpj, string email, bool intencaoDeAprovacao)
        {
            Cnpj = cnpj;
            Email = email;
            IntencaoDeAprovacao = intencaoDeAprovacao;
        }

        public string Cnpj { get; private set; }
        public string Email { get; private set; }
        public bool IntencaoDeAprovacao { get; private set; }
    }
}