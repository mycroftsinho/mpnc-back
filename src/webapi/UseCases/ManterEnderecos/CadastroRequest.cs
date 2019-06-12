namespace webapi.UseCases.ManterEnderecos
{
    public class CadastroRequest
    {
        public int Id { get; set; }

        public int LojaId { get; set; }

        public string Rua { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }
    }
}