namespace usecase.Cases.ManterProdutos.Input
{
    public class EntradaParaGravarOuAlterarProduto
    {
        public EntradaParaGravarOuAlterarProduto(int produtoId, string descricao, decimal valor, int lojaId)
        {
            ProdutoId = produtoId;
            Descricao = descricao;
            Valor = valor;
            LojaId = lojaId;
        }

        public int ProdutoId { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public int LojaId { get; private set; }
    }
}