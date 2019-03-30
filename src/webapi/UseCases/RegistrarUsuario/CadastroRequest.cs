namespace webapi.UseCases.RegistrarUsuario
{
    public class CadastroRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}