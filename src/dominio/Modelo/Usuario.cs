namespace dominio.Modelo
{
    public abstract class Usuario
    {
        protected Usuario(string nome, string email, string telefone)
        {
            DefinirNome(nome);
            DefinirEmail(email);
            DefinirTelefone(telefone);
        }

        protected Usuario()
        {

        }

        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Telefone { get; private set; }

        protected void DefinirTelefone(string telefone)
        {
            if (!string.IsNullOrWhiteSpace(telefone)) Telefone = telefone;
        }

        protected void DefinirEmail(string email)
        {
            if (!string.IsNullOrWhiteSpace(email)) Email = email;
        }

        protected void DefinirNome(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome)) Nome = nome;
        }
    }
}