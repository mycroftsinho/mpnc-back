namespace usecase.Cases.ManterLojas.Input
{
    public class EntradaParaAlterarDadosDaLoja
    {
        public EntradaParaAlterarDadosDaLoja(string nome, string email, string telefone, string cep, string rua, string bairro, string numero)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cep = cep;
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Cep { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Numero { get; private set; }
    }
}