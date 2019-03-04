using dominio.Scopers;
using FluentValidation.Results;

namespace dominio.Modelo
{
    public class Cota
    {
        public Cota(int lojaId, int quantidade)
        {
            LojaId = lojaId;
            Quantidade = quantidade;
        }

        public int Id { get; private set; }

        public int LojaId { get; private set; }

        public int Quantidade { get; private set; }

        public Loja Loja { get; private set; }

        public void DefinirQuantidadeDeCota(int quantidade)
        {
            Quantidade = quantidade;
        }

        public ValidationResult Validar()
        {
            return new ValidacaoDaCota().Validate(this);
        }

    }
}