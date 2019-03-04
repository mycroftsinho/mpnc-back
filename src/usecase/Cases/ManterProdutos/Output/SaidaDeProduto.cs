using dominio.Modelo;

namespace usecase.Cases.ManterProdutos.Output
{
    public class SaidaDeProduto
    {
        public SaidaDeProduto(Produto produto)
        {
            Id = produto.Id;
            Descricao = produto.Descricao;
            Valor = produto.Valor;
        }

        public int? Id { get; private set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }
    }
}