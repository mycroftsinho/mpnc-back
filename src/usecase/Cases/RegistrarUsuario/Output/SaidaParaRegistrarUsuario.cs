using System.Collections.Generic;
using FluentValidation.Results;

namespace usecase.Cases.RegistrarUsuario.Output
{
    public class SaidaParaRegistrarUsuario
    {
        public SaidaParaRegistrarUsuario(bool situacao)
        {
            Situacao = situacao;
        }

        public SaidaParaRegistrarUsuario(bool situacao, IList<ValidationFailure> errors)
        {
            Situacao = situacao;
            Errors = errors;
        }

        public bool Situacao { get; private set; }

        public IList<ValidationFailure> Errors { get; private set; }
    }
}