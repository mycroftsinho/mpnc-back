using System.Collections.Generic;
using FluentValidation.Results;

namespace usecase.Cases.ManterLojas.Output
{
    public class SaidaDeAlteracaoDeLojas
    {
        public SaidaDeAlteracaoDeLojas(bool situacao, ICollection<SaidaDeLoja> lojas = null, IList<ValidationFailure> errors = null)
        {
            Situacao = situacao;
            Lojas = lojas;
            Erros = errors;
        }

        public bool Situacao { get; private set; }

        public ICollection<SaidaDeLoja> Lojas { get; private set; }

        public ICollection<ValidationFailure> Erros {get; private set;}
    }
}