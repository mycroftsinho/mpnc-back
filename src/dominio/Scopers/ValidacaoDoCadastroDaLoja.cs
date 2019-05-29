using dominio.Modelo;
using FluentValidation;

namespace dominio.Scopers
{
    public class ValidacaoDoCadastroDaLoja : AbstractValidator<Loja>
    {
        public ValidacaoDoCadastroDaLoja()
        {
            RuleFor(x => x.Cnpj).NotNull().WithMessage("Cnpj inválido!");
            RuleFor(x => x.Representante).NotNull().WithMessage("Representante Inválido!");
            RuleFor(x => x.Empresa).NotNull().WithMessage("Empresa inválida!");
            RuleFor(x => x.Telefone).NotNull().WithMessage("Telefone inválido!");
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Email inválido!");
        }
    }
}