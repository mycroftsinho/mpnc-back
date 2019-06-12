namespace usecase.Cases.ManterEnderecos.Input
{
    public class EntradaParaGravarOuAlterarEndereco
    {
        public EntradaParaGravarOuAlterarEndereco(int id, int lojaId, string rua, string numero, string bairro, string cep)
        {
            Id = id;
            LojaId = lojaId;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cep = cep;
        }
        
        public EntradaParaGravarOuAlterarEndereco(int lojaId, string rua, string numero, string bairro, string cep)
        {
            Id = 0;
            LojaId = lojaId;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cep = cep;
        }

        public int Id { get; private set; }

        public int LojaId { get; private set; }

        public string Rua { get; private set; }

        public string Numero { get; private set; }

        public string Bairro { get; private set; }

        public string Cep { get; private set; }
    }
}