namespace usecase.Cases.AprovarSolicitacaoDeCadastro.Input
{
    public class EntradaParaObterSolicitacao
    {
        public EntradaParaObterSolicitacao(string email, string cnpj)
        {
            Email = email;
            Cnpj = cnpj;
        }

        public string Email { get; private set; }

        public string Cnpj { get; private set; }
    }
}