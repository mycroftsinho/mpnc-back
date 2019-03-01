using dominio.Modelo;
using FluentValidation;

namespace dominio.Scopers
{
    public class ValidacaoDoCadastroDaLoja : AbstractValidator<Loja>
    {
        public ValidacaoDoCadastroDaLoja()
        {
            RuleFor(x => x.Cep).NotNull().Length(8, 8).WithMessage("Cep inválido!");
            RuleFor(x => x.Rua).NotNull().Length(2, 150).WithMessage("Rua inválida!");
            RuleFor(x => x.Bairro).NotNull().Length(2, 150).WithMessage("Bairro inválido!");
            RuleFor(x => x.Numero).NotNull().Length(1, 8).WithMessage("Número inválido!");
        }
    }
}