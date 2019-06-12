namespace usecase.Cases.ManterEnderecos.Input
{
    public class EntradaParaBuscarEndereco
    {
        public EntradaParaBuscarEndereco(int lojaId = 0, int enderecoId = 0)
        {
            LojaId = lojaId;
            EnderecoId = enderecoId;
        }

        public int LojaId { get; private set; }

        public int EnderecoId { get; private set; }
    }
}