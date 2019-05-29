namespace usecase.Cases.SolicitarCadastro.Input
{
    public class EntradaDeSolicitacaoDeCadastro
    {
        public EntradaDeSolicitacaoDeCadastro(string nome, string email, string telefone, string cnpj, string empresa)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cnpj = cnpj;
            Empresa = empresa;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Cnpj { get; private set; }
        public string Empresa { get; private set; }
    }
}