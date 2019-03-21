using dominio.Modelo;
using FluentValidation;

namespace dominio.Scopers
{
    public class ValidacaoDoLogin : AbstractValidator<Login>
    {
        public ValidacaoDoLogin()
        {
            RuleFor(x => x.UserName).NotNull().Length(0, 20).WithMessage("UserName inválido");
            RuleFor(x => x.AccessKey).NotNull().Length(0, 32).WithMessage("Chave de Acesso inválida!");
        }
    }
}