using dominio.Scopers;
using FluentValidation.Results;

namespace dominio.Modelo
{
    public class Produto
    {
        public Produto(int lojaId, string descricao, decimal valor)
        {
            DefinirInformacoes(descricao, valor, lojaId);
        }

        public int Id { get; private set; }

        public int LojaId { get; private set; }

        public string Descricao { get; private set; }

        public decimal Valor { get; private set; }

        public Loja Loja { get; private set; }

        public ValidationResult Validar()
        {
            return new ValidacaoDoProduto().Validate(this);
        }

        public void DefinirInformacoes(string descricao, decimal valor, int lojaId)
        {
            Descricao = descricao;
            Valor = valor;
            LojaId = lojaId;
        }
    }
}