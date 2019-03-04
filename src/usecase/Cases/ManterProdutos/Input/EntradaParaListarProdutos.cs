namespace usecase.Cases.ManterProdutos.Input
{
    public class EntradaParaListarProdutos
    {
        public EntradaParaListarProdutos(int lojaId, int id)
        {
            LojaId = lojaId;
            Id = id;
        }

        public int LojaId { get; private set; }

        public int Id { get; private set; }
    }
}