using dominio.Modelo;

namespace usecase.Cases.ManterLojas.Output
{
    public class SaidaDeLoja
    {
        public SaidaDeLoja(Loja loja)
        {
            LojaId = loja.Id;
            Nome = loja.Empresa;
            Email = loja.Email;
            Telefone = loja.Telefone;
        }

        public int LojaId { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
    }
}