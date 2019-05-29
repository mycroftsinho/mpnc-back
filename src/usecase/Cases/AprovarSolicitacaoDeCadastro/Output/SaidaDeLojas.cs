using dominio.Modelo;

namespace usecase.Cases.AprovarSolicitacaoDeCadastro.Output
{
    public class SaidaDeLojas
    {
        public SaidaDeLojas(Loja loja)
        {
            Nome = loja.Empresa;
            Email = loja.Email;
            Telefone = loja.Telefone;
            Cep = loja.Cep;
            Rua = loja.Rua;
            Bairro = loja.Bairro;
            Numero = loja.Numero;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Cep { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Numero { get; private set; }
    }
}