namespace usecase.Cases.ManterEnderecos.Input
{
    public class EntradaParaGravarOuAlterarEndereco
    {
        public EntradaParaGravarOuAlterarEndereco(int id, string email, string rua, string numero, string bairro, string cep, string contentType = null, byte[] imagem = null)
        {
            Id = id;
            Email = email;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cep = cep;
            ContentType = contentType;
            Imagem = imagem;
        }
        
        public EntradaParaGravarOuAlterarEndereco(string email, string rua, string numero, string bairro, string cep, string contentType = null, byte[] imagem = null)
        {
            Id = 0;
            Email = email;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cep = cep;
            ContentType = contentType;
            Imagem = imagem;
        }

        public int Id { get; private set; }

        public string Email { get; private set; }

        public string Rua { get; private set; }

        public string Numero { get; private set; }

        public string Bairro { get; private set; }

        public string Cep { get; private set; }

        public string ContentType{ get; private set; }

        public byte[] Imagem { get; private set; }
    }
}