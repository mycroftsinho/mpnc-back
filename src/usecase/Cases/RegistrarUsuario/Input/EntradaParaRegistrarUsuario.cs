namespace usecase.Cases.RegistrarUsuario.Input
{
    public class EntradaParaRegistrarUsuario
    {
        public EntradaParaRegistrarUsuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public string Nome { get; private set; }

        public string Email { get; private set; }
        
        public string Senha { get; private set; }
    }
}