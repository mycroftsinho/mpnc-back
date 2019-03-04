namespace usecase.Cases.ManterProdutos.Input
{
    public class EntradaParaRemoverProduto
    {
        public EntradaParaRemoverProduto(int produtoId)
        {
            ProdutoId = produtoId;
        }

        public int ProdutoId { get; private set; }
    }
}