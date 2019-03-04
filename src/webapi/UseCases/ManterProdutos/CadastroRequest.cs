namespace webapi.UseCases.ManterProdutos
{
    public class CadastroRequest
    {
        public int ProdutoId { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public int LojaId { get; private set; }
    }
}