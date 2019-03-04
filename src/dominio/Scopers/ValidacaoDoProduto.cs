using dominio.Modelo;
using FluentValidation;

namespace dominio.Scopers
{
    public class ValidacaoDoProduto : AbstractValidator<Produto>
    {
        public ValidacaoDoProduto()
        {
            RuleFor(x => x.Descricao).NotEmpty().NotNull().Length(2,150);
            RuleFor(x => x.Valor).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(x => x.LojaId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}