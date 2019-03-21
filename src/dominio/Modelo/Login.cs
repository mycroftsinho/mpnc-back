using dominio.Scopers;
using FluentValidation.Results;

namespace dominio.Modelo
{
    public class Login
    {
        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string AccessKey { get; private set; }
        
        public ValidationResult Validar()
        {
            return new ValidacaoDoLogin().Validate(this);
        }
    }
}