namespace usecase.Cases.ManterEnderecos.Input
{
    public class EntradaParaBuscarEndereco
    {
        public EntradaParaBuscarEndereco(string email)
        {
            Email = email;
        }

        public EntradaParaBuscarEndereco(int lojaId = 0, int enderecoId = 0)
        {
            LojaId = lojaId;
            EnderecoId = enderecoId;
        }

        public int LojaId { get; private set; }

        public int EnderecoId { get; private set; }

        public string Email { get; private set; }
    }
}