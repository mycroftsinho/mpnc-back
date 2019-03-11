namespace usecase.Cases.ManterLojas.Input
{
    public class EntradaParaAlterarDadosDaLoja
    {
        public EntradaParaAlterarDadosDaLoja(int lojaId, string nome, string email, string telefone, string cep, string rua, string bairro, string numero)
        {
            LojaId = lojaId;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cep = cep;
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
        }

        public int LojaId { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Cep { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Numero { get; private set; }
    }
}