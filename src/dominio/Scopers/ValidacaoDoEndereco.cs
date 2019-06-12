using dominio.Modelo;
using FluentValidation;

namespace dominio.Scopers
{
    public class ValidacaoDoEndereco : AbstractValidator<Endereco>
    {
        public ValidacaoDoEndereco()
        {
            RuleFor(x => x.LojaId).NotEmpty().NotNull();
            RuleFor(x => x.Cep).NotEmpty().NotNull();
            RuleFor(x => x.Rua).NotEmpty().NotNull();
            RuleFor(x => x.Numero).NotEmpty().NotNull();
            RuleFor(x => x.Bairro).NotEmpty().NotNull();
        }
    }
}