using dominio.Modelo;
using FluentValidation;

namespace dominio.Scopers
{
    public class ValidacaoDoLogin : AbstractValidator<Usuario>
    {
        public ValidacaoDoLogin()
        {
            RuleFor(x => x.Email).NotNull().Length(0, 100).WithMessage("UserName inválido");
            RuleFor(x => x.Password).NotNull().Length(0, 100).WithMessage("Chave de Acesso inválida!");
            RuleFor(x => x.PerfilDeAcesso).NotNull().Length(0, 32).WithMessage("Chave de Acesso inválida!");
        }
    }
}