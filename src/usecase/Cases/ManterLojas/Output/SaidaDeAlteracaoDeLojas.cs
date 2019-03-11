using System.Collections.Generic;
using FluentValidation.Results;

namespace usecase.Cases.ManterLojas.Output
{
    public class SaidaDeAlteracaoDeLojas
    {
        public SaidaDeAlteracaoDeLojas(bool situacao, ICollection<SaidaDeLoja> lojas = null, SaidaDeLoja loja = null, IList<ValidationFailure> errors = null)
        {
            Situacao = situacao;
            Lojas = lojas;
            Loja = loja;
            Erros = errors;
        }

        public bool Situacao { get; private set; }

        public SaidaDeLoja Loja { get; private set; }

        public ICollection<SaidaDeLoja> Lojas { get; private set; }

        public ICollection<ValidationFailure> Erros { get; private set; }
    }
}