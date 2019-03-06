namespace usecase.Cases.AprovarSolicitacaoDeCadastro.Input
{
    public class EntradaParaObterSolicitacao
    {
        public EntradaParaObterSolicitacao(string email, string nome)
        {
            Email = email;
            Nome = nome;
        }

        public string Email { get; private set; }

        public string Nome { get; private set; }
    }
}