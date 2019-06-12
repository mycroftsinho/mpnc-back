namespace usecase.Cases.ManterEnderecos.Input
{
    public class EntradaParaRemoverEndereco
    {
        public EntradaParaRemoverEndereco(int enderecoId)
        {
            EnderecoId = enderecoId;
        }

        public int EnderecoId { get; private set; }
    }
}