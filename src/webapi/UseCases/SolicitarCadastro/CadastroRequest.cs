namespace webapi.UseCases.SolicitarCadastro
{
    public class CadastroRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Empresa { get; set; }
        public string Cnpj { get; set; }
    }
}