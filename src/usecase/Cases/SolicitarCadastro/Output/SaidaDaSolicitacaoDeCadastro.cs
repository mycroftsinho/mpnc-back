using FluentValidation.Results;
using System.Collections.Generic;

namespace usecase.Cases.SolicitarCadastro.Output
{
    public class SaidaDaSolicitacaoDeCadastro
    {
        public SaidaDaSolicitacaoDeCadastro(bool resultado, IList<ValidationFailure> errors = null)
        {
            Resultado = resultado;
            Erros = errors;
        }

        public bool Resultado { get; private set; }

        public IList<ValidationFailure> Erros { get; private set; }
    }
}