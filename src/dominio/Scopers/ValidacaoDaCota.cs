using dominio.Modelo;
using FluentValidation;

namespace dominio.Scopers
{
    public class ValidacaoDaCota : AbstractValidator<Cota>
    {
        public ValidacaoDaCota()
        {
            RuleFor(x => x.LojaId).NotEmpty().NotNull();
            RuleFor(x => x.Quantidade).NotEmpty().NotNull();
        }
    }
}