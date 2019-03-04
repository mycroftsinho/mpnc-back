using System.Collections.Generic;
using FluentValidation.Results;

namespace usecase.Cases.ManterProdutos.Output
{
    public class SaidaDeAlteracoesDeProdutos
    {
        public SaidaDeAlteracoesDeProdutos(bool situacao, ICollection<SaidaDeProduto> produtos = null, SaidaDeProduto produto = null, IList<ValidationFailure> errors = null)
        {
            Situacao = situacao;
            Produtos = produtos;
            Produto = produto;
            Erros = errors;
        }

        public bool Situacao { get; private set; }

        public SaidaDeProduto Produto { get; private set; }

        public ICollection<SaidaDeProduto> Produtos { get; private set; }

        public IList<ValidationFailure> Erros { get; private set; }
    }
}