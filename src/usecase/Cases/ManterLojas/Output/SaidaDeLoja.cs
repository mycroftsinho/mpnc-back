using dominio.Modelo;

namespace usecase.Cases.ManterLojas.Output
{
    public class SaidaDeLoja
    {
        public SaidaDeLoja(Loja loja)
        {
            LojaId = loja.Id;
            Nome = loja.NomeDaLoja;
            Email = loja.Email;
            Telefone = loja.Telefone;
            Cep = loja.Cep;
            Rua = loja.Rua;
            Bairro = loja.Bairro;
            Numero = loja.Numero;
        }

        public int LojaId { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Cep { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Numero { get; private set; }
    }
}